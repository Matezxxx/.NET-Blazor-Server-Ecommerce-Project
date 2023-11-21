using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services;
using EcommerceProject.App.Pages.OrderPages;
using Microsoft.AspNetCore.Components;

namespace EcommerceProject.App.Pages.CustomerPages
{
    public partial class OrderHistory
    {


        [Parameter]
        public Customer? Customer {get; set;}
        public List<Order> Orders = new List<Order>();
        public List<Customer>Customers = new List<Customer>();
        public List<Product>Products = new List<Product>();
        [Parameter]
        public int CustomerId { get; set;}


        protected override void OnInitialized()
        {
           
            Customers = customerService.GetAll();

        }

        protected void Get()
        {
            customerService.GetOrderHistory();
        }
    }

}
