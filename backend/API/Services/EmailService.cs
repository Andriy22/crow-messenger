using Application.Common.Constants;
using Application.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace API.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _smtpFromTitle;

        public EmailService(IConfiguration configuration)
        {
            _smtpServer = configuration["SMTP:Server"] ?? throw new Exception("Invalid smtp server");
            _smtpPort = int.Parse(configuration["SMTP:Port"] ?? throw new Exception("Invalid smtp server"));
            _smtpUsername = configuration["SMTP:Username"] ?? throw new Exception("Invalid smtp username");
            _smtpPassword = configuration["SMTP:Password"] ?? throw new Exception("Invalid smtp server");
            _smtpFromTitle = configuration["SMTP:FromTitle"] ?? EmailConstants.SmtpFrom;
        }

        public async Task SendEmailAsync(string to, string subject, string htmlContent)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_smtpFromTitle, _smtpUsername));
            message.To.Add(new MailboxAddress(string.Empty, to));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = htmlContent
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_smtpServer, _smtpPort, true);
            await client.AuthenticateAsync(_smtpUsername, _smtpPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
