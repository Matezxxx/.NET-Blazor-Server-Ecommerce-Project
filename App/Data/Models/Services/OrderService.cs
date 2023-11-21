using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using EcommerceProject.App.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NuGet.Protocol.Plugins;

namespace EcommerceProject.App.Data.Models.Services
{
    public class OrderService:IOrderService
    {
        private readonly ApplicationContext dbContext;
        public OrderService(IDbContextFactory<ApplicationContext> ctx)
        {

            dbContext = ctx.CreateDbContext();
        }
        public async Task Save(Order order)
        {
            dbContext.Orders.Update(order);
           await dbContext.SaveChangesAsync();
        }
        
        public async Task<List<Order>> GetOrder()
        {
           
            var OrdersList = await dbContext.Orders.Include(o => o.Products).ToListAsync();
            var CustomerList = await dbContext.Customers.ToListAsync();
           
            return OrdersList;
        }
        public List<Order> GetAll()
        {
            
           
            {
                return dbContext.Orders
                    .Include(o => o.Products)
                    .Include(o => o.Customer)
                    
                    .ToList();
            }
        }
        public void DeleteOrder(Order order)
        {
          
                 dbContext.Remove(order);
            

                dbContext.SaveChanges();

        }

        public async Task UpdateOrder(Order order)
        {          
                dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync();
            
            
        }
       
        public Order GetOrderById(int orderId)
        {
           
            return dbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }


    }
    }






