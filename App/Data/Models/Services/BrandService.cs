using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Data.Entity;

namespace EcommerceProject.App.Data.Models.Services
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationContext DbContext;
        public BrandService(IDbContextFactory<ApplicationContext> ctx)
        {
            DbContext = ctx.CreateDbContext();
        }
        public bool AddUpdate(Brand brand)
        {

            if (brand.BrandId == 0)
            {
                DbContext.Brands.Add(brand);

                DbContext.SaveChanges();

            }
            else
            {
                DbContext.Brands.Update(brand);

                DbContext.SaveChanges();
            }

            return true;


        }
        public void DeleteBrand(Brand brand)
        {
            DbContext.Remove(brand);
            DbContext.SaveChanges();
        }
        public Brand GetBrandById(int brandId)
        {
            return DbContext.Brands.FirstOrDefault(b => b.BrandId == brandId);
        }
        public Brand FindById(int BrandId)
        {
            return DbContext.Brands.Find(BrandId);
        }
        public List<Brand> GetAll()
        {
            DbContext.Categories.ToList();
            DbContext.Products.ToList();
            DbContext.BrandLogos.ToList();
            return DbContext.Brands.ToList();
        }
    }
}
