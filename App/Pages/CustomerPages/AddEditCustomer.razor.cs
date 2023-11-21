using EcommerceProject.App.Data.Models.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace EcommerceProject.App.Pages.CustomerPages
{
    public partial class AddEditCustomer
    {
        [Parameter]
        public int CustomerId { get; set; }
        public List<Customer> Customer=new List<Customer>();
        public List<Product>Products = new List<Product>();
        public List<Order> Orders = new List<Order>();
        private string message = string.Empty;
        Customer customer = new Customer();
        private string title = "Přidej Zákazníka";
        int selectedTab = 0;

        private async Task Save()
        {
            if (customerService.AddUpdate(customer))
            {
                var result = await ds.Confirm("Jste si jistý?");
                customer = new();
                message = "Zákazník úspěšně přidán";
                Task.Delay(20000);
                navMan.NavigateTo("/customer");
            }
            else
            {
                message = "Zákazník nemohl být přidán";
            }    
        }
        protected override void OnInitialized()
        {
            if (CustomerId > 0)
            {
                title = "Aktualizuj zákazníka";
                customer = customerService.FindById(CustomerId);
            }
            base.OnInitialized();

        }
        public void BackToList()
        {
            navMan.NavigateTo("/customer");
        }

    }
}
