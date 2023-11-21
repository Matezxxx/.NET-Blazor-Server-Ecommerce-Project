using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.App.Data.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Jméno zákazníka je povinné.")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Email je povinný.")]
        [EmailAddress(ErrorMessage = "Neplatný formát emailu.")]
        public string CustomerEmail { get; set; } = string.Empty;
        [Required(ErrorMessage = "Telefonní číslo je povinné.")]
        [RegularExpression(@"^\+\d{12}$", ErrorMessage = "Neplatný formát telefonního čísla.")]
        public string CustomerPhone { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
