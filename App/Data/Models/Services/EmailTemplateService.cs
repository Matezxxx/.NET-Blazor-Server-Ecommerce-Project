using EcommerceProject.App.Data.Models.Entities;
using EcommerceProject.App.Data.Models.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EcommerceProject.App.Data.Models.Entities;
using System.Data.Entity;
using Bogus.DataSets;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting.Server;
using System.Net.Mail;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.CodeAnalysis;

namespace EcommerceProject.App.Data.Models.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly ApplicationContext dbContext;

        public EmailTemplateService(IDbContextFactory<ApplicationContext> ctx)
        {
            dbContext = ctx.CreateDbContext();
        }
        public MimeMessage SendEmail(string reciever,string body,string subject)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("From", "harry@gmail.com"));
            email.To.Add(new MailboxAddress("To", reciever));
            email.Subject= subject;
            var bodyBuilder=new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            email.Body=bodyBuilder.ToMessageBody();


            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("localhost", 1025);
            smtp.Send(email);
            smtp.Disconnect(true);

            return email;
        }
       
        public async Task DeleteEmailTemplate(EmailTemplate emailTemplate)
        {
            dbContext.EmailTemplates.Remove(emailTemplate);
            await dbContext.SaveChangesAsync();
        }

        public bool AddUpdate(EmailTemplate emailTemplate)
        {
            if (emailTemplate == null)
            {
                return false; // Šablona je null, nelze provést vložení nebo aktualizaci
            }

            if (dbContext.EmailTemplates.Any(e => e.Code == emailTemplate.Code))
            {
                // Aktualizace
                dbContext.EmailTemplates.Update(emailTemplate);
            }
            else
            {
                // Vložení
                dbContext.EmailTemplates.Add(emailTemplate);
            }

            dbContext.SaveChanges(); // Uložení změn

            return true; // Úspěšně provedeno vložení nebo aktualizace
        }

        public List<EmailTemplate> GetAll()
        {
            return dbContext.EmailTemplates.ToList();
        }
        public EmailTemplate FindByCode(string Code)
        {
           
            return dbContext.EmailTemplates.Find(Code);
        }
        public EmailTemplate FindByCodeWhere(string Code)
        {
            return dbContext.EmailTemplates.FirstOrDefault(x => x.Code == "Process");
        }
    }
}



