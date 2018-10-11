using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CbWebApp.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirme seu email",
                $"Por favor confirme sua conta clicando neste link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
