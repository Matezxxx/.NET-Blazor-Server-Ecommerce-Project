using EcommerceProject.App.Data.Models.Components;
using EcommerceProject.App.Data.Models.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Radzen;

namespace EcommerceProject.App.Pages.EmailTemplates
{
    public partial class AddEditEmail:ComponentBase
    {

        EmailTemplate template = new EmailTemplate();

        [Parameter]
        public string Code { get; set; }
        string htmlValue = "<h1>Hello World!</h1>";

        ConsoleLog console;

        void OnPaste(HtmlEditorPasteEventArgs args)
        {
            console.Log($"Paste: {args.Html}");
        }

        void OnChange(string html)
        {
            console.Log($"Change: {html}");
        }

        void OnInput(string html)
        {
            console.Log($"Input: {html}");
        }

        void OnExecute(HtmlEditorExecuteEventArgs args)
        {
            console.Log($"Execute: {args.CommandName}");
        }
        private async Task<EmailTemplate> GetTemplate(string Code)
        {
            // Načtení dat z databáze nebo z API
            // Při použití DbContext to bude zhruba takto:
            return await dbContext.EmailTemplates.FirstOrDefaultAsync(t => t.Code == Code);
        }
        protected override void OnInitialized()
        {
            if (Code != null)
            {
                template = emailTemplateService.FindByCode(Code);
            }
            base.OnInitialized();
        }

        private async Task SaveTemplate()
        {
            if (emailTemplateService.AddUpdate(template))
            {
                template = new();
                var result = await ds.Confirm("Jste si jistý?");
                navMan.NavigateTo("/emailTemplate");
            }

        }
        private void BackToList()
        {
            navMan.NavigateTo("/emailTemplate");
        }
    }
}
