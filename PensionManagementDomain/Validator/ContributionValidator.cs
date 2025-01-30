using FluentValidation;
using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.Validator
{
    public class ContributionValidator: AbstractValidator<Contribution>
    {

        public ContributionValidator()
        {
            RuleFor(c => c.MemberId)
       .GreaterThan(0).WithMessage("Member ID must be a valid positive number.");

            RuleFor(c => c.Type)
                .IsInEnum().WithMessage("Invalid contribution type. Must be Monthly or Voluntary.");

            RuleFor(c => c.Amount)
                .GreaterThan(0).WithMessage("Contribution amount must be greater than zero.");

            RuleFor(c => c.ContributionDate)
                .NotEmpty().WithMessage("Contribution date is required.")
                .Must(BeAValidDate).WithMessage("Invalid contribution date.");

            RuleFor(c => c.ReferenceNumber)
                .NotEmpty().WithMessage("Reference number is required.")
                .Matches(@"^[A-Z0-9]{10,20}$").WithMessage("Reference number must be 10-20 characters long and contain only uppercase letters and numbers.");

            RuleFor(c => c)
                .Must(ValidateMonthlyContribution).WithMessage("Monthly contribution must be within the same calendar month.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default;
        }

        private bool ValidateMonthlyContribution(Contribution contribution)
        {
            if (contribution.Type == ContributionType.Monthly)
            {
                var now = DateTime.UtcNow;
                return contribution.ContributionDate.Month == now.Month && contribution.ContributionDate.Year == now.Year;
            }
            return true;
        }

    }
}
