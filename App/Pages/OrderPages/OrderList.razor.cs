using EcommerceProject.App.Data.Models.Services;
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Routes;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using EcommerceProject.App.Data.Models.Seed;
using System.Reflection;
using EcommerceProject.App.Data.Models.Services.Interfaces;
using Radzen.Blazor;

namespace EcommerceProject.App.Pages.OrderPages
{
    public partial class OrderList:ComponentBase
    {

        [Parameter]
        public List<Order> Orders {  get; set; }=new List<Order>();
        [Parameter]
        public List<Product> Products { get; set; } = new List<Product>();
        private RadzenDataGrid<Order> ordgrid;

        [Parameter]
        public EventCallback<Order> OnOrderProcessed { get; set; }
        [Parameter]
        public EventCallback<Order> OnOrderDeleted { get; set; }

        private string title = "Objednávky";

      
        private async Task LoadData()
        {
            Orders = orderService.GetAll();
        }
        public string GetProcessedText(int processedValue)
        {
            return processedValue == 1 ? "Čeká na zpracování" : "Zpracováno";
        }
        private async Task ProcessOrderAsync(Order order)
        {
             await OnOrderProcessed.InvokeAsync(order);
             await ordgrid.Reload();
        }

        private async Task DeleteOrder(Order order)
        {
            await OnOrderDeleted.InvokeAsync(order);
            await ordgrid.Reload();
        }

        private async Task HandleSearchByOrderId(string filter)
        {

            if (!string.IsNullOrWhiteSpace(filter))
            {
                Orders = Orders.Where(p =>p.OrderId.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {

                Orders = orderService.GetAll();
            }
        }
        private async Task HandleSearchByProcessed(string filter)
        {

            if (!string.IsNullOrWhiteSpace(filter))
            {
                Orders = Orders.Where(p => p.Processed.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {

                Orders = orderService.GetAll();
            }
        }
       // private async Task HandleSearchByProductName(string filter)
        //{

          //  if (!string.IsNullOrWhiteSpace(filter))
            //{
              //  productOrders =productOrders.Where(p => p.ProductName.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            //}
            //else
            //{

              //  productOrders = productOrders;
            //}
        //}
    }
   
  


}
