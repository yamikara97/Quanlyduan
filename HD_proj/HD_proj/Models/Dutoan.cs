using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Dutoan
    {
        [Display (Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display (Name = "Dự toán")]
        public int Sotien { get; set; }



    }
}
