using EcommerceProject.App.Data.Models.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EcommerceProject.App.Data.Models.Services
{
    public class ProductService : IProductService
    {

        private readonly IDbContextFactory<ApplicationContext> ctx;
        public ProductService(IDbContextFactory<ApplicationContext> ctx)
        {

            this.ctx = ctx;
        }
        public void DeleteProduct(Product product)
        {
            using var context = ctx.CreateDbContext();
            {
                context.Remove(product);
                context.SaveChanges();
               
            }
        }
        public bool AddUpdate(Product product)
        {
            using var DbContext = ctx.CreateDbContext();
            {
                if (product.ProductId == 0)
                {
                    DbContext.Products.Add(product);
                    DbContext.SaveChanges();
                }
                else
                {
                    DbContext.Products.Update(product);
                    DbContext.SaveChanges();
                }
                return true;
            }
        }
        public Product FindById(int ProductId)
        {
            using var DbContext = ctx.CreateDbContext();
            return DbContext.Products.Find(ProductId);
        }

        public List<Product> GetAll()
        {
            using var DbContext = ctx.CreateDbContext();
            DbContext.Categories.ToList();
            DbContext.Brands.ToList();
            return DbContext.Products.ToList();
        }
        public Product GetProductById(int productId)
        {
            using var dbContext = ctx.CreateDbContext();
            return dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
      //  public List<Order> GetAllProductOrders(int productId)
        //{
          //  using var dbContext = ctx.CreateDbContext();
            //return dbContext.ProductOrders
              //  .Where(po => po.ProductId == productId)
                //.Select(po => po.Order)
                //.ToList();
        //}
    }
}
