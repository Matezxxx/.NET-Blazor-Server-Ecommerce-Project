using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen.Blazor;
using Radzen;
using EcommerceProject.App.Data.Models.Components;

namespace EcommerceProject.App.Pages.BrandPages
{
    public partial class AddEditBrand
    {
        [Parameter]
        public int BrandId { get; set; }
        public int? BrandLogoId { get; set; }
        private string message = string.Empty;
        Brand brand = new Brand();
        private string title = "Přidej značku";
        public virtual BrandLogo? brandLogo { get; set; }

        private byte[] uploadedFile;



       
        public async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                using var ms = new MemoryStream();
                {
                   await file.OpenReadStream().CopyToAsync(ms);
                    brandLogo = new BrandLogo
                    {
                        BrandLogoName = file.Name,
                        Size = ms.ToArray(),
                        MIMEType = file.ContentType
                    };
                };
                // Uložení obrázku do databáze
                brandLogoService.SaveBrandLogo(brandLogo);
                // Přiřazení loga k značce
                brand.BrandLogo = brandLogo;
            }
            // Uložení značky do databáze
            brandService.AddUpdate(brand);
        }

        private void Save()
        {
            if (brandService.AddUpdate(brand))
            {
                brand.BrandLogo = brandLogo;
                brand = new();
                message = "Značka úspěšně přidána";
                navMan.NavigateTo("/brand");
            }

            if (brandLogo != null)
            {
                // Uložení loga do databáze
                brandLogoService.SaveBrandLogo(brandLogo);

                // Přiřazení loga k značce
                brand.BrandLogo = brandLogo;
                navMan.NavigateTo("/brand");
            }
            else
            {
                message = "Značka nemohla být přidána";
            }


        }
        protected override void OnInitialized()
        {
            if (BrandId > 0)
            {

                // Načtení značky z databáze
                brand = brandService.GetBrandById(BrandId);
                brandLogo = brandLogoService.GetBrandLogo();
                base.OnInitialized();
            }
        }
        public void Cancel()
        {
            navMan.NavigateTo("/brand");
        }

        private void SaveBrand()
        {
            if (brand != null)
            {
                if (brandLogo != null)
                {
                    // Uložení loga do databáze
                    brandLogoService.SaveBrandLogo(brandLogo);

                    // Přiřazení loga k značce
                    brand.BrandLogo = brandLogo;
                }

                // Uložení značky do databáze
                brandService.AddUpdate(brand);
            }
        }
       
    }
}

