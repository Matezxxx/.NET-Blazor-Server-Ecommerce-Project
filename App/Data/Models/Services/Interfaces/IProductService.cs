using EcommerceProject.App.Data.Models.Entities;
using System.Threading.Tasks;

namespace EcommerceProject.App.Data.Models.Services
{
    public interface IProductService

    {

        bool AddUpdate(Product product);
        void DeleteProduct(Product product);

        Product FindById(int Productid);

        List<Product> GetAll();


        Product GetProductById(int productId);
    }      
}
