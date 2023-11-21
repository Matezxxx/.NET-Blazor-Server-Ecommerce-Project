using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.App.Data.Models.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }
 
    public int CategoryId { get; set; }
   
    public int BrandId { get; set; }
    
    public int StockQuantity { get; set; } = 3;
   
    [Required(ErrorMessage = "Název produktu je povinný.")]
    public string ProductName { get; set; }
    [StringLength(255)]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Cena produktu je povinná.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Cena musí být větší než nula.")]
    public decimal Price { get; set; }
    public bool Active { get; set; } = true;
   
    public virtual Category Category { get; set; }
    
    public virtual Brand Brand { get; set; }

  
    public virtual ICollection<Order> Orders { get; set; }= new List<Order>();

}

