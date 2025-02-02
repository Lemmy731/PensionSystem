using FluentValidation;
using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.Validator
{
    public class EmployerValidator: AbstractValidator<Employer>
    {
        //employer validator
        public EmployerValidator()
        {
            RuleFor(e => e.CompanyName)
        .NotEmpty().WithMessage("Company name is required.")
        .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");

            RuleFor(e => e.RegistrationNumber)
        .NotEmpty().WithMessage("Registration number is required.")
        .Matches(@"^RC\d+$").WithMessage("Registration number must start with 'RC' followed by digits.");


            RuleFor(e => e.IsActive)
                .NotNull().WithMessage("Employer active status must be specified.");
        }
    }
}
