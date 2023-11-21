using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EcommerceProject.App.Data.Models.Services
{
    public class BrandLogoService: IBrandLogoService
    {
        private readonly IDbContextFactory<ApplicationContext> _ctx;

        public BrandLogoService(IDbContextFactory<ApplicationContext> ctx)
        {
            _ctx=ctx;
        }

        public BrandLogo GetBrandLogo()
        {
            using var dbContext =_ctx.CreateDbContext();
            return dbContext.BrandLogos.FirstOrDefault();
        }
        public BrandLogo GetBrandLogoById(int BrandLogoId) {
            using var dbContext = _ctx.CreateDbContext();
            return dbContext.BrandLogos.FirstOrDefault(bl => bl.BrandLogoId == BrandLogoId);
        }
        public void SaveBrandLogo(BrandLogo brandLogo)
        {
            using var dbContext = _ctx.CreateDbContext();
            dbContext.BrandLogos.Add(brandLogo);
       
        }
        public List<BrandLogo> GetAll()
        {
            using var DbContext = _ctx.CreateDbContext();
           
            DbContext.Brands.ToList();
           
            return DbContext.BrandLogos.ToList();
        }
    }
}
