using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services;
using Microsoft.AspNetCore.Components;

namespace EcommerceProject.App.Pages.CategoryPages
{
    public partial class AddEditCategory
    {
        [Parameter]
        public int CategoryId { get; set; }
        private string message = string.Empty;
        Category category = new Category();
        private string title = "Přidej kategorii";

        private void Save()
        {


            if (categoryService.AddUpdate(category))
            {

                category = new();
                message = "Kategorie úspěšně přidána";
                navMan.NavigateTo("/category");


            }
            else
            {
                message = "Kategorie nemohla být přidána";
            }
        }
        public void BackToList()
        {
            navMan.NavigateTo("/category");
        }

        protected override void OnInitialized()
        {
            if (CategoryId > 0)
            {
                title = "Aktualizuj Kategorii";
                category = categoryService.FindById(CategoryId);
            }
            base.OnInitialized();

        }
    }
}
