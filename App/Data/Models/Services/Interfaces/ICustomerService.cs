using EcommerceProject.App.Data.Models.Entities;

namespace EcommerceProject.App.Data.Models.Services
{
    public interface ICustomerService
    {
        bool AddUpdate(Customer customer);

        Customer FindById(int CustomerId);
        Task DeleteCustomer(Customer customer);
        List<Customer> GetAll();
        Task GetOrderHistory();
        public Customer GetCustomerById(int customerId);
    }
}
