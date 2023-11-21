using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.App.Data.Models.Entities
{
    public class EmailTemplate
    {
        [Required(ErrorMessage = "Název emailu je povinný.")]
        public string Name { get; set; }
        [Key]
        [Required(ErrorMessage = "kód je povinný.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "předmět je povinný.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Obsah je povinný.")]
        public string Body { get; set; }
    }
}
