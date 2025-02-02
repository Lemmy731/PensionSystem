using FluentValidation;
using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.Validator
{
    public class BenefitValidator: AbstractValidator<Benefit>
    {
        //benefit validator
        public BenefitValidator()
        {
            RuleFor(b => b.MemberId)
        .GreaterThan(0).WithMessage("Member ID must be valid.");

            RuleFor(b => b.Type)
                .IsInEnum().WithMessage("Invalid benefit type.");

            RuleFor(b => b.CalculationDate)
                .NotEmpty().WithMessage("Calculation date is required.")
                .Must(BeAValidDate).WithMessage("Invalid calculation date.");

            RuleFor(b => b.EligibilityStatus)
                .NotNull().WithMessage("Eligibility status must be specified.");

            RuleFor(b => b.Amount)
                .GreaterThanOrEqualTo(0).WithMessage("Benefit amount cannot be negative.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default;
        }
    }
}
