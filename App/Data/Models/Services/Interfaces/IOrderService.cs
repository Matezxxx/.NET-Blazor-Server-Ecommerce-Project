using EcommerceProject.App.Data.Models.Entities;

namespace EcommerceProject.App.Data.Models.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrder();
        public List<Order> GetAll();
        public Task UpdateOrder(Order order);
        public Order GetOrderById(int orderId);
        public void DeleteOrder(Order order);
        public Task Save(Order order);
     
    }
}
