using Microsoft.AspNetCore.Http;

namespace SavorySeasons.Backend.Email.Models
{
    public class EmailData
    {
        public string ToEmailId { get; set; }

        public string ToName { get; set; }

        public string CcEmailId { get; set; }

        public string CcName { get; set; }

        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }

        public List<IFormFile> Attachments { get; set; } = new List<IFormFile>();
    }
}
