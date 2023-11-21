using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.App.Data.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Název kategorie je povinný.")]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
