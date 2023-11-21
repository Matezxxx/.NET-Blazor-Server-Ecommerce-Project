using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services;
using EcommerceProject.App.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis.Differencing;
using Radzen.Blazor;
using System.Net.Mail;

namespace EcommerceProject.App.Pages.EmailTemplates
{
    public partial class EmailTemplates
    {
        private List<EmailTemplate> emailTemplates = new List<EmailTemplate>();
        private RadzenDataGrid<EmailTemplate> emGrid;

        protected override void OnInitialized()
        {
            emailTemplates = emailTemplateService.GetAll();
        }
        public async Task LoadData()
        {

            emailTemplates = emailTemplateService.GetAll();

        }
        private void AddUpdate(string Code)
        {
            navMan.NavigateTo($"/emailTemplate/edit/{Code}");

        }
        private void AddUpdate()
        {
            navMan.NavigateTo("/emailTemplate/Add/");
        }
        private async Task DeleteEmailTemplate(EmailTemplate emailTemplate)
        {

            await emailTemplateService.DeleteEmailTemplate(emailTemplate);
            await emGrid.Reload();


        }



    }
}

