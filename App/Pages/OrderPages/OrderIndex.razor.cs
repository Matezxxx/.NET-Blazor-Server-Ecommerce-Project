using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services;
using EcommerceProject.App.Data.Models.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Radzen.Blazor;
using System.Configuration;
using System.Data.Entity;

namespace EcommerceProject.App.Pages.OrderPages
{
    public partial class OrderIndex : ComponentBase
    {
       
      
        public List<Order> OrderList { get; set; } = new List<Order>();
        [Parameter]
        public List<Product> Products { get; set; } = new List<Product>();
        public List<EmailTemplate> EmailTemplates { get; set; }= new List<EmailTemplate>();
        [Parameter]
        public string Code { get; set; }
        [Parameter]
        public string Body { get; set; }
        [Parameter]
        public string Subject { get; set; }




        protected override void OnInitialized()
        {           
            //Tímto načteme databázový kontext z komponenty OrderList
            OrderList =  orderService.GetAll();
        }
        public async Task OnOrderDeleted(Order order)
        {
            orderService.DeleteOrder(order);
            OrderList = orderService.GetAll();          
        }
        private void OnOrderProcessed(Order order)
        {
            order.Processed = (int)Processed2.Zpracovano;

            foreach (var productToUpdate in order.Products)
                {
                    if (productToUpdate.StockQuantity > 0)
                    {
                        productToUpdate.StockQuantity--;

                        if (productToUpdate.StockQuantity <= 0)
                        {
                            productToUpdate.Active = false;
                        }
                    }
                }
               orderService.Save(order);

            var IdOfCust = customerService.GetCustomerById(order.Customer.CustomerId);
            var reciever= IdOfCust.CustomerEmail;
           
            var Idoftemp = emailTemplateService.FindByCodeWhere(Code);
            var body = Idoftemp.Body;
           
            var subject = Idoftemp.Subject;

            emailTemplateService.SendEmail(reciever, body,subject);
        }
    }
}


 

