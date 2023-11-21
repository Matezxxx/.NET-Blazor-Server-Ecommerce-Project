using EcommerceProject.App.Data.Models.Entities;

namespace EcommerceProject.App.Data.Models.Services
{
    public interface ICategoryService
    {
        bool AddUpdate(Category category);

        Category FindById(int CategoryId);
        Task DeleteCategory(Category category);

        List<Category> GetAll();
    }
}
