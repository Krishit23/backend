using SavorySeasons.Backend.Email.Models;

namespace SavorySeasons.Backend.Email.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailData emailData);
    }
}
