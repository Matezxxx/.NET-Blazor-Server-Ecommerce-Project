using EcommerceProject.App.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EcommerceProject.App.Data.Models.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationContext dbContext;
        public CustomerService(IDbContextFactory<ApplicationContext> ctx)
        {

           dbContext = ctx.CreateDbContext();
        }



        public bool AddUpdate(Customer customer)
        {
                if (customer.CustomerId == 0)
                {
                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();

                }
                else
                {
                    dbContext.Customers.Update(customer);
                    dbContext.SaveChanges();
                }
                return true;
            }

        
        public Customer FindById(int CustomerId)
        {
            
            return dbContext.Customers.Include(o => o.Orders).ThenInclude(o=>o.Products).SingleOrDefault(o=>o.CustomerId==CustomerId);
        }
        public async Task GetOrderHistory()
        {
           dbContext.Customers.Include(o => o.Orders).ThenInclude(o => o.Products);
            return;
        }
        public async Task DeleteCustomer(Customer customer)
        {
            dbContext.Customers.Remove(customer);
            
            await dbContext.SaveChangesAsync();
        }
        public Customer GetCustomerById(int customerId)
        {
          
            return dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public List<Customer> GetAll()
        {
            

            return dbContext.Customers
                .Include(o => o.Orders)
                .ThenInclude(o=>o.Products)
                .ToList();
                
        }
    }
}
