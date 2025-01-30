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
        public EmployerValidator()
        {
            RuleFor(e => e.CompanyName)
        .NotEmpty().WithMessage("Company name is required.")
        .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");

            RuleFor(e => e.RegistrationNumber)
                .NotEmpty().WithMessage("Registration number is required.")
                .Matches(@"^[A-Z0-9]{5,50}$").WithMessage("Registration number must be alphanumeric and 5-50 characters long.");

            RuleFor(e => e.IsActive)
                .NotNull().WithMessage("Employer active status must be specified.");
        }
    }
}
