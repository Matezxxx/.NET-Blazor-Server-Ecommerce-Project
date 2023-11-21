using EcommerceProject.App.Data.Models.Components;
using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Radzen;
using System.Text.Json;

namespace EcommerceProject.App.Pages.ProductPages
{
    public partial class AddEditProduct
    {


        [Parameter]
        public int ProductId { get; set; }
      
        private string message = string.Empty;
        Product product = new Product();
        private bool Active { get; set; } = true;
        private string title = "Přidej produkt";
        public List<Category> categories;
        public List<Brand> brands;
        
        bool popup;

        
        ConsoleLog console;

        void Log(string eventName, string value)
        {
            console.Log($"{eventName}: {value}");
        }

        void OnSubmit(Product product)
        {
            Log("Submit", JsonSerializer.Serialize(product, new JsonSerializerOptions() { WriteIndented = true }));
        }

        void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            Log("InvalidSubmit", JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true }));
        }
    

    private async Task Save()
        {
            if (productService.AddUpdate(product))
            {
                var result = await ds.Confirm("Jste si jistý?");
                product =new ();
                message = "Produkt úspěšně přidán";
                navMan.NavigateTo("/product");
                

            }
            else
            {
                message = "Produkt nemohl být přidán";
            }
            
        }
        protected override void OnInitialized()
        {
            if (ProductId > 0)
            {
                title = "Aktualizuj produkt";
                product = productService.FindById(ProductId);
                categories = categoryService.GetAll();
                brands = brandService.GetAll();
            }
            else
            {
               
                categories = categoryService.GetAll();
                brands = brandService.GetAll();

            }
            base.OnInitialized();

        }

    }
}
