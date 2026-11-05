using System;
using System.Net;
using System.Net.Mail;

namespace Capa_Logica
{
    public static class EnviarMail
    {
        public static void sendMail(string to, string asunto, string body)
        {
            string from = "soportepp44@gmail.com";
            string displayName = "Sistema";

            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(from, displayName)
                };
                mail.To.Add(to);
                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(from, "dlrlelzfqoseawey"),
                    EnableSsl = true
                };

                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con el servidor de correo: " + ex.Message);
            }
        }
    }
}