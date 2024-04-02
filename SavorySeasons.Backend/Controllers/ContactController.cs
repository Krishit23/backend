using Microsoft.AspNetCore.Mvc;
using SavorySeasons.Backend.Email.Models;
using SavorySeasons.Backend.Email.Services;
using SavorySeasons.Backend.Models;

namespace SavorySeasons.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ContactController : ControllerBase
    {
        private readonly IEmailService  _emailService;
        private readonly ContactUsConfiguration _contactUsConfiguration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ContactController(IEmailService emailService,
            ContactUsConfiguration contactUsConfiguration,
            IWebHostEnvironment webHostEnvironment)
        {
            _emailService = emailService;
            _contactUsConfiguration = contactUsConfiguration;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpPost]
        public async Task<ActionResult> Post(ContactUs contact)
        {

            var html = await System.IO.File.ReadAllTextAsync($"{this._webHostEnvironment.WebRootPath.ToLower()}/Template/ContactUs.html");

            html = html.Replace("##YouTube##", $"{"common/youtube.png"}");
            html = html.Replace("##Whatsapp##", $"{"common/whatsapp.png"}");
            html = html.Replace("##Twitter##", $"{"common/twitter.png"}");
            html = html.Replace("##Linkedin##", $"{"common/linkedin.png"}");
            html = html.Replace("##CompanyLogo##", $"{"common/email-logo.png"}");

            html = html.Replace("##FirstName##", $"{contact.FirstName}");
            html = html.Replace("##LastName##", contact.LastName);
            html = html.Replace("##Email##", contact.Email);
            html = html.Replace("##MobileNumber##", contact.MobileNumber);
            html = html.Replace("##Message##", contact.Message);
            EmailData emailData = new EmailData();
            emailData.ToEmailId = _contactUsConfiguration.Email;
            emailData.EmailSubject = "New Inquiry";
            emailData.EmailBody = html;
            await _emailService.SendEmail(emailData);
            return Ok();

        }
    }
}
