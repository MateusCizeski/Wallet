﻿using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Services.Notification
{
    public class ServSendGridEmailNotificationService : IServSendGridEmailNotificationService
    {
        private readonly string _sendGridApiKey;
        private readonly string _senderEmail;
        private readonly string _senderName;

        public ServSendGridEmailNotificationService(IConfiguration configuration)
        {
            _sendGridApiKey = configuration["SendGrid:ApiKey"];
            _senderEmail = configuration["SendGrid:SenderEmail"];
            _senderName = configuration["SendGrid:SenderName"];
        }

        public async Task NotifyTransferAsync(string receiverEmail, decimal amount)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress(_senderEmail, _senderName);
            var subject = "Transferência Recebida!";
            var to = new EmailAddress(receiverEmail);
            var plainTextContent = $"Você recebeu uma transferência de R${amount:F2}. Verifique sua carteira.";
            var htmlContent = $"<strong>Você recebeu uma transferência de R${amount:F2}. Verifique sua carteira.</strong>";

            var message = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(message);

            if ((int)response.StatusCode >= 400)
            {
                throw new Exception($"Falha ao enviar e-mail. Código de status: {response.StatusCode}");
            }
        }
    }
}
