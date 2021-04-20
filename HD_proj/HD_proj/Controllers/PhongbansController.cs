using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HD_proj.Data;
using HD_proj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using HD_proj.Areas.Identity.Pages.Account;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.WebUtilities;

namespace HD_proj.Controllers
{
    public class PhongbansController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public PhongbansController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
             IWebHostEnvironment env
            )
        {
            _env = env;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        // GET: Phongbans
        public async Task<IActionResult> Index()
        {
            var department = await _context.Phongbans.ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", department);
            }
            return View(department);
        }

        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var i = Request.Query["Ma"];
            ViewBag.Father = "";
            if (i != "")
            {
                ViewBag.Father = i;
            }
            var department = new Phongban();

            if (id.HasValue)
            {

                department = await _context.Phongbans.FindAsync(id);
                ViewBag.Father = department.MaPhongbanCha;
            }

            return PartialView("_OrderPartial", department);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid? id, [Bind("Ten,Cap,Ma,Id,DateUpdate,MaPhongbanCha,UpdateBy")] Phongban department, IFormCollection collect)
        {
            department.UpdateBy = User.Identity.Name;

            department.Ma = getCode(department.MaPhongbanCha, department.Ten);
            if (ModelState.IsValid)
            {
          
                try
                {
                    if (id.HasValue)
                    {
                        if (collect["oldCode"] != "")
                        {
                            var listdep = _context.Phongbans.Where(a => a.Id != department.Id).ToList();
                            foreach (var item in listdep)
                            {
                                if (item.Ma != "" && item.Ma != null)
                                {
                                    if (item.MaPhongbanCha != null && item.MaPhongbanCha.Contains(collect["oldCode"]))
                                    {
                                        item.MaPhongbanCha = item.MaPhongbanCha.Replace(collect["oldCode"], department.Ma);
                                        _context.Phongbans.Update(item);
                                    }
                                }
                            }
                        }
                        _context.Phongbans.Update(department);
                        _context.SaveChanges();
                        TempData["Notifications"] = "Sửa thành công";
                    }
                    else
                    {
                        var test = _context.Phongbans.Where(a => a.Ten == department.Ten || a.Ma == department.Ma).FirstOrDefault();
                        if (test == null)
                        {
                            _context.Phongbans.Add(department);
                        }

                        TempData["Notifications"] = " Thêm thành công";

                    }
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !PhongbanExists(department.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Index", "Phongbans");
        }

        public string getCode(string father, string name)
        {
            string[] namearray = name.Trim().Split(" ");
            string valref = father == null ? "" : (father + "_");
            for (int i = 0; i < namearray.Count(); i++)
            {
                if (namearray[i] != null && namearray[i] != "")
                {
                    if (i == namearray.Count() - 1)
                    {
                        if (long.TryParse(namearray[i], out long ret))
                        {
                            valref += namearray[i];
                        }
                        else
                        {
                            valref += namearray[i].ToString().ToUpper();

                        }
                    }
                    else
                    {
                        valref += namearray[i][0].ToString().ToUpper();
                    }

                }
            }
            return valref;
        }


        // GET: Phongbans/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Phongbans.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: department);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var department = await _context.Phongbans.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            try
            {
                foreach (var item in _context.Phongbans)
                {
                    if (item.MaPhongbanCha == department.Ma)
                    {
                        item.MaPhongbanCha = "";
                        _context.Phongbans.Update(item);
                    }
                }
                _context.Phongbans.Remove(department);

                _context.SaveChanges();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Phongbans");
        }

        private bool PhongbanExists(Guid id)
        {
            return _context.Phongbans.Any(e => e.Id == id);
        }
    }
}
