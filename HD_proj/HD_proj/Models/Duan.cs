using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Duan : IdentityBase
    {
        [Display(Name = "Tên dự án")]
        public string Ten { get; set; }

        [Display (Name = "Mô tả dự án")]
        public string Mota { get; set; }

        [Display (Name = "Thời hạn")]
        public DateTime Thoihan { get; set; }

        [Display (Name = "Hoàn thành")]
        public bool Hoanthanh { get; set; }

    }
}
