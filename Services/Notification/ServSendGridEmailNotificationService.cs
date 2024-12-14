using System.Net;
using System.Net.Mail;

namespace Services.Notification
{
    public class ServSendGridEmailNotificationService : IServSendGridEmailNotificationService
    {
        private readonly string _sendGridApiKey;

        public SendGridEmailNotificationService(string sendGridApiKey)
        {
            _sendGridApiKey = sendGridApiKey;
        }

        public async Task NotifyTransferAsync(string receiverEmail, decimal amount)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("seuemail@dominio.com", "Nome do Remetente"); // Email e nome do remetente
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
