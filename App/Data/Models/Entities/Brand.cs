using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.App.Data.Models.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
      
        public int? BrandLogoId {get; set; }
        [Required(ErrorMessage = "Název značky je povinný.")]
        public string BrandName { get; set; }
        public virtual BrandLogo? BrandLogo { get; set; }
    }
}
