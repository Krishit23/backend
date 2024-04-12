using FluentValidation;
using SavorySeasons.Backend.Models;

namespace SavorySeasons.Backend.Validation.ModelValidation
{
    public class ContactValidator :AbstractValidator<ContactUs>
    {
        public ContactValidator()
        {
            RuleFor(_ => _.Email).EmailAddress(); 
            RuleFor(_ => _.MobileNumber).NotNull().GreaterThan(0); 
        }
    }
}
