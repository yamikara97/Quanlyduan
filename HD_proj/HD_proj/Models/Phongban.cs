using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Phongban : IdentityBase
    {
        [Display(Name = "Tên phòng ban")]
        public string Ten { get; set; }

        [Display(Name = "Cấp")]
        public int Cap { get; set; }

        [Display(Name = "Mã Phòng Ban")]
        public string Ma { get; set; }

        public string MaPhongbanCha { get; set; }

    }
}
