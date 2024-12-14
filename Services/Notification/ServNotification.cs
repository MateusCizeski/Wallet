using System.Net;
using System.Net.Mail;

namespace Services.Notification
{
    public class ServNotification : IServNotification
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPassword;

        public ServNotification(string smtpHost, int smtpPort, string smtpUser, string smtpPassword)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _smtpUser = smtpUser;
            _smtpPassword = smtpPassword;
        }

        public async Task NotifyTransferAsync(string receiverEmail, decimal amount)
        {
            var fromEmail = _smtpUser;
            var subject = "Transferência Recebida!";
            var body = $"Você recebeu uma transferência de R${amount:F2}. Verifique sua carteira.";

            using (var smtpClient = new SmtpClient(_smtpHost, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage(fromEmail, receiverEmail, subject, body);

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine($"E-mail enviado com sucesso para {receiverEmail}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                }
            }
        }
    }
}
