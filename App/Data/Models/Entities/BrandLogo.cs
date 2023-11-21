using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.App.Data.Models.Entities
{
    public class BrandLogo
    {
        [Key]
        public int BrandLogoId { get; set; }

        public string BrandLogoName { get; set; }
        public byte[] Size { get; set; }
        public string MIMEType { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
