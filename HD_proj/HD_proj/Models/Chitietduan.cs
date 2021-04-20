using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Chitietduan : IdentityBase
    {
        public enum status
        {
            NOT = 0,
            BEGIN = 1,
            DURING = 2,
            CANCEL = 3,
            FINISH = 4
        }

        [Display (Name = "Tên nhiệm vụ")]
        public string Name { get; set; }

        [Display (Name = "Chi tiết nhiệm vụ")]
        public string Chitiet { get; set; }

        [Display (Name = "Tình trạng")]
        public status Tinhtrang { get; set; }

        public Guid Duan { get; set; }

    }
}
