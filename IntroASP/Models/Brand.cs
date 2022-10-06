using System;
using System.Collections.Generic;

namespace IntroASP.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Birras = new HashSet<Birra>();
        }

        public int BrandId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Birra> Birras { get; set; }
    }
}
