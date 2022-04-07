using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PG.Models.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
    public class EmailSender: IEmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                           ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }
            await Execute(Options.SendGridKey, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("yugi.el.capo@gmail.com", "Recifaca");
            var to = new EmailAddress(toEmail, "Example User");
            var plainTextContent = "Bienvenido a Recifacapp, \n" +
                "El lugar donde conectamos las personas que queremos un cambio \n " +
                "Tu codigo es: " + message;
            var htmlContent = "Bienvenido a Recifacapp, \n" +
                "El lugar donde conectamos las personas que queremos un cambio \n " + 
                "Tu codigo es: " + message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}