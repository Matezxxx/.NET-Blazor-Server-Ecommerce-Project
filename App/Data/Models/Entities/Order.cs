using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Security.Permissions;
using System.Diagnostics.CodeAnalysis;

namespace EcommerceProject.App.Data.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [EnumDataType(typeof(Processed2))]
        public int Processed { get; set; } = (int)Processed2.Zpracovano|(int)Processed2.Zpracovano;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    
        public virtual Customer Customer { get; set; }
       
    }
    public class DisplayAttribute : Attribute
    {
        public string Name { get; set; }

        public DisplayAttribute(string name)
        {
            Name = name.ToString();
        }
    }
    public enum Processed2
    {
        [Display(name:"Zpracováno")]
       Zpracovano,
        [Display(name:"Čeká na zpracování")]
        CekaNaZpracovani=1
    }
   
}
