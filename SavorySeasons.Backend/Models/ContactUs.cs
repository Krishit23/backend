using Org.BouncyCastle.Asn1.Mozilla;

namespace SavorySeasons.Backend.Models
{
    public class ContactUs
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; } = "savoryseasons@yopmail.com";

        public int MobileNumber { get; set; }

        public string Message { get; set; }
    }
}
