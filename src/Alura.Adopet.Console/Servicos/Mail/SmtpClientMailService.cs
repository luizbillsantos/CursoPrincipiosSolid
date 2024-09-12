using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net;
using System.Net.Mail;

namespace Alura.Adopet.Console.Servicos.Mail
{
    public class SmtpClientMailService : IMailService
    {
        private readonly SmtpClient _smtpClient;

        public SmtpClientMailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendMailAsync(string remetente, string destinatario,
            string titulo, string corpo)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("meu_email@gmail.com", "minha_senha"),
                EnableSsl = true,
                UseDefaultCredentials = false,

            };

            // Configurações do e-mail
            var mailMessage = new MailMessage
            {
                From = new MailAddress("meu_email@gmail.com"),
                Subject = "[Service - Serviço que manda e-mail]",
                Body = "Exemplod e envio de email",
            };
            mailMessage.To.Add("meu_email@gmail.com");

            // Enviar o e-mail
            smtpClient.Send(mailMessage);
        }
    }
}
