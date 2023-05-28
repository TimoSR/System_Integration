using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

class Program
{
    static async Task Main()
    {
        DotNetEnv.Env.Load();
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var fromUser = "Timothy Rasmussen";
        var fromEmailAddress = "Timothy.s.rasmussen@gmail.com";
        var toEmailAddress = "Timothy.s.rasmussen@gmail.com";
        var toUSer = "Timothy Rasmussen";
        var msgTXT = "System Integration is fun and AMAZING!";

        var client = new SendGridClient(apiKey);
        var from = new EmailAddress(fromEmailAddress, fromUser);
        var subject = "Proof of Working Email Service!";
        var to = new EmailAddress(toEmailAddress, toUSer);
        var plainTextContent = msgTXT;
        var htmlContent = $"<strong>{msgTXT}</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
    }
}