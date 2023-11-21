using EcommerceProject.App.Data.Models.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.App.Data.Models.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationContext DbContext;
        public CategoryService(IDbContextFactory<ApplicationContext> ctx)
        {

            DbContext = ctx.CreateDbContext();
        }



        public bool AddUpdate(Category category)
        {
            if (category.CategoryId == 0)
            {
                DbContext.Categories.Add(category);
                DbContext.SaveChanges();

            }
            else
            {
                DbContext.Categories.Update(category);
                DbContext.SaveChanges();
            }

            return true;

        }
        public Category FindById(int CategoryId)
        {
            return DbContext.Categories.Find(CategoryId);
        }
        public async Task DeleteCategory(Category category)
        {
            DbContext.Categories.Remove(category);
           await DbContext.SaveChangesAsync();
        }


        public List<Category> GetAll()
        {
            DbContext.Products.ToList();
            DbContext.Brands.ToList();
            return DbContext.Categories.ToList();
        }
    }
}


