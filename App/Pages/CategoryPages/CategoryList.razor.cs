using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services;
using EcommerceProject.App.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Reflection;

namespace EcommerceProject.App.Pages.CategoryPages
{
    public partial class CategoryList
    {
        public List<Category> categories = new();
        private int _countCategories;
        private string title = "Kategorie";
        [Parameter]
        public int CategoryId { get; set; }
        private RadzenDataGrid<Category> catgrid;

        protected override void OnInitialized()
        {
            categories = categoryService.GetAll();

        }
        private async Task LoadData()
        {
           
            categories = categoryService.GetAll();
        }
        private async Task DeleteCategory(Category category)
        {
            await categoryService.DeleteCategory(category);
            catgrid.Reload();
        }
        private async Task HandleSearchByCategory(string filter)
        {

            if (!string.IsNullOrWhiteSpace(filter))
            {
                categories = categories.Where(p => p.CategoryName.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {

                categories = categoryService.GetAll();
            }
        }
        private void AddUpdate(int CategoryId)
        {
            navMan.NavigateTo($"/category/edit/{CategoryId}");

        }
        private void AddUpdate()
        {
            navMan.NavigateTo("/category/Add");

        }
    }
}
