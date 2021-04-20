using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Phancong :IdentityBase
    {
        public Guid ChitietDuan { get; set; }

        public Guid Nguoilam { get; set; }
    }
}
