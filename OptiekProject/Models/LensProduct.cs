using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Models
{
    public class LensProduct : Product
    {
        public int LensProductID { get; set; }
        public string LensType { get; set; }
        public int aantal { get; set; }
    }
}
