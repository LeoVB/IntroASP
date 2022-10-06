using System;
using System.Collections.Generic;

namespace IntroASP.Models
{
    public partial class Birra
    {
        public int BeerId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Brand Brand { get; set; } = null!;
    }
}
