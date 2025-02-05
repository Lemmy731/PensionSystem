using FluentValidation;
using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.Validator
{
    public class MemberValidator : AbstractValidator<Member>
    {
        //member validator
        public MemberValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty();
            RuleFor(m => m.LastName).NotEmpty();
            RuleFor(m => m.DateOfBirth)
                .Must(dob => dob <= DateTime.UtcNow.AddYears(-18) && dob >= DateTime.UtcNow.AddYears(-70))
                .WithMessage("Age must be between 18 and 70 years.");
            RuleFor(m => m.Email).EmailAddress();
            RuleFor(m => m.PhoneNumber).Matches(@"^\+?[1-9][0-9]{7,14}$").WithMessage("Invalid phone number format.");
        }

    }
}
