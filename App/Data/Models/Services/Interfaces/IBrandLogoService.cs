using EcommerceProject.App.Data.Models.Entities;

namespace EcommerceProject.App.Data.Models.Services.Interfaces
{
    public interface IBrandLogoService
    {
        BrandLogo GetBrandLogo();
        BrandLogo GetBrandLogoById(int BrandLogoId);
        public void SaveBrandLogo(BrandLogo brandLogo);
        public List<BrandLogo> GetAll();

    }

}
