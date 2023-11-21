using EcommerceProject.App.Data.Models.Services;
using EcommerceProject.App.Data.Models.Entities;
using Radzen.Blazor;
using Radzen;
using EcommerceProject.App.Data.Models.Components;

namespace EcommerceProject.App.Pages.BrandPages
{
    public partial class BrandList
    {
        public List<Brand> brand = new List<Brand>();
        public List<BrandLogo> logo = new List<BrandLogo>();
        private RadzenDataGrid<Brand> brandGrid;

        private string title = "Značky";
        protected override void OnInitialized()
        {
            brand = brandService.GetAll();
            logo = brandLogoService.GetAll();
        }
        private async Task HandleSearchByBrand(string filter)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                brand = brand.Where(p => p.BrandName.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                brand = brandService.GetAll();
            }
        }
        private void LoadData()
        {
             brand = brandService.GetAll();
            logo =  brandLogoService.GetAll();
        }
        private void DeleteBrand(Brand brand)
        {
            brandService.DeleteBrand(brand);
            brandGrid.Reload();
        }
        private void AddUpdate(int BrandId)
        {
            navMan.NavigateTo($"/brand/edit/{BrandId}");
        }
        private void AddUpdate()
        {
            navMan.NavigateTo("/brand/add");
        }

    }
}
