using EcommerceProject.App.Data.Models.Services;
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Routes;
using EcommerceProject.App.Pages.OrderPages;
using Microsoft.EntityFrameworkCore;
using Azure;
using System.ComponentModel;
using System.Data.Entity;

namespace EcommerceProject.App.Pages.ProductPages
{
    public partial class ProductsList
    {
        public List<Product> product = new List<Product>();
        
        public List<Category> category =new List<Category>();
        public bool Active { get; set; } = true;
        
        [Parameter]
        public int StockQuantity { get; set; }
        [Parameter]
        public int ProductId { get; set; }
        
        private string title = "Produkty";
        [Parameter]
        public EventCallback<int> OnOrderProcessed { get; set; }

        protected override void OnInitialized()
        {
            product = productService.GetAll();
        }

        private void AddUpdate(int ProductId)
        {
            navMan.NavigateTo($"/product/edit/{ProductId}");
            
        }
        private void AddUpdate()
        {
            navMan.NavigateTo("/product/add/");
        }
        private void DeleteProduct(Product product)
        {
            productService.DeleteProduct(product);
            OnInitialized();
        }

        ///Metods for filtering while using html instead of Radzen
        ///
        //private async Task HandleSearchByName(string filter)
        //{
        //    if (!string.IsNullOrWhiteSpace(filter))
        //    {
        //        product = product.Where(p => p.ProductName.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
        //    }
        //    else
        //    {

        //        product = productService.GetAll();
        //    }

        //}
        //private async Task HandleSearchByCategory(string filter)
        //{

        //    if (!string.IsNullOrWhiteSpace(filter))
        //    {
        //        product = product.Where(p => p.Category.CategoryName.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
        //    }
        //    else
        //    {

        //        product = productService.GetAll();
        //    }
        //}
        //private async Task HandleSearchByBrand(string filter)
        //{

        //    if (!string.IsNullOrWhiteSpace(filter))
        //    {
        //        product = product.Where(p => p.Brand.BrandName.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
        //    }
        //    else
        //    {

        //        product = productService.GetAll();
        //    }
        //}
    }
}
