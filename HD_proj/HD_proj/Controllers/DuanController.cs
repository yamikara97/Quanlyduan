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
    public class DuanController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;

        public DuanController(ApplicationDbContext context,
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

        // GET: Duan
        public async Task<IActionResult> Index()
        {
            var duAn = await _context.Duan.ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", duAn);
            }
            return View(duAn);
        }

        // GET: Duan/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duan = await _context.Duan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duan == null)
            {
                return NotFound();
            }

            return View(duan);
        }

        // GET: Duan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ten,Mota,Thoihan,Hoanthanh,Id,DateUpdate,UpdateBy")] Duan duan)
        {
            if (ModelState.IsValid)
            {
                duan.Id = Guid.NewGuid();
                _context.Add(duan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duan);
        }

        // GET: Duan/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duan = await _context.Duan.FindAsync(id);
            if (duan == null)
            {
                return NotFound();
            }
            return View(duan);
        }

        // POST: Duan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Ten,Mota,Thoihan,Hoanthanh,Id,DateUpdate,UpdateBy")] Duan duan)
        {
            if (id != duan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuanExists(duan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(duan);
        }

        // GET: Duan/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duan = await _context.Duan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duan == null)
            {
                return NotFound();
            }

            return View(duan);
        }

        // POST: Duan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var duan = await _context.Duan.FindAsync(id);
            _context.Duan.Remove(duan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuanExists(Guid id)
        {
            return _context.Duan.Any(e => e.Id == id);
        }
    }
}
