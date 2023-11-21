using EcommerceProject.App.Data.Models.Entities;
using MimeKit;

namespace EcommerceProject.App.Data.Models.Services.Interfaces
{
    public interface IEmailTemplateService
    {
        bool AddUpdate(EmailTemplate emailTemplate);
        EmailTemplate FindByCode(string Code);
        EmailTemplate FindByCodeWhere(string Code);
        List<EmailTemplate> GetAll();
        Task DeleteEmailTemplate(EmailTemplate emailTemplate);
        public MimeMessage SendEmail(string reciever,string body,string subject);
    }
}
