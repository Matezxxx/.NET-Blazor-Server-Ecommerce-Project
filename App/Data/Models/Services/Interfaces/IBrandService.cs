using EcommerceProject.App.Data.Models.Entities;

namespace EcommerceProject.App.Data.Models.Services.Interfaces
{
    public interface IBrandService
    {
        bool AddUpdate(Brand brand);
        void DeleteBrand(Brand brand);

        Brand FindById(int BrandId);
        Brand GetBrandById(int brandId);

        List<Brand> GetAll();
    }
}
