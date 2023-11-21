
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Routes;
using EcommerceProject.App.Data.Models.Services;
using Radzen.Blazor;
using EcommerceProject.App.Pages.EmailTemplates;
using Microsoft.CodeAnalysis.Differencing;

namespace EcommerceProject.App.Pages.CustomerPages


{
    public partial class CustomerList
    {

        
        public List<Customer> customers = new List<Customer>();
        private RadzenDataGrid<Customer> custgrid;


        public bool Active { get; set; } = true;
        private string title = "Zákazníci";


        protected override void OnInitialized()
        {
          
            customers = customerService.GetAll();


        }
        public async Task LoadData()
        {


            customers = customerService.GetAll();
            
        }
        private async Task DeleteCustomer(Customer customer)
        {
          
            await customerService.DeleteCustomer(customer);
            await custgrid.Reload(); 


        }
        private async Task HandleSearchByName(string filter)
        {

            if (!string.IsNullOrWhiteSpace(filter))
            {
                customers = customers.Where(p => p.CustomerName.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {

                customers = customerService.GetAll();
            }
        }
        private void AddUpdate(int CustomerId)
        {
            navMan.NavigateTo($"/customer/edit/{CustomerId}");


        }
        private void AddUpdate()
        {
            navMan.NavigateTo("/customer/Add/");
        }
    }
}
