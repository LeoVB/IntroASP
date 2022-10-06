using System.ComponentModel.DataAnnotations;

namespace IntroASP.Models.ViewModels
{
    public class BirraViewModel //clase para formularios, separados del EF
    {
        [Required]
        [Display (Name= "Nombre")]
        public int BrandId { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Id")]
        public int BeerId { get; set; }

    }
}
