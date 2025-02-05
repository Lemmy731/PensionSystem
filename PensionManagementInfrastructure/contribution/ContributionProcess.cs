using Microsoft.EntityFrameworkCore;
using PensionManagementDomain.Entity;
using PensionManagementInfrastructure.DataAccess;
using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementInfrastructure.CalculatessBenfit;
using PensionManagementDomain.DTO;

namespace PensionManagementInfrastructure.contribution
{
    //contribution process
    public class ContributionProcess: IContributionProcess
    {
        private readonly AppDbContext _context;
        private readonly IBenefitCalculation _benefitCalculation;

        public ContributionProcess(AppDbContext context, IBenefitCalculation benefitCalculation)
        {
            _context = context;
            _benefitCalculation = benefitCalculation;
        }

        public async Task<string> ProcessContribution(int memberId, decimal amount, ContributionType type)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var member = _context.Members
                    .Include(m => m.Benefit)
                    .FirstOrDefault(m => m.MemberId == memberId);

                if (member == null)
                    return "Member not found";

                DateTime currentDate = DateTime.Now;
                int currentMonth = currentDate.Month;
                int currentYear = currentDate.Year;

                // Check for multiple monthly contributions within the same month
                if (type == ContributionType.Monthly)
                {
                    bool hasExistingMonthly = _context.Contributions.Any(c =>
                        c.MemberId == memberId &&
                        c.Type == ContributionType.Monthly &&
                        c.ContributionDate.Month == currentMonth &&
                        c.ContributionDate.Year == currentYear);

                    if (hasExistingMonthly)
                        return "A monthly contribution already exists for this month.";
                }

                // Handle ContributionMonth tracking
                if (member.ContributionMonths == 0)
                {
                    member.ContributionMonths = currentMonth;
                    member.ContributionMonthsCount = 1; // First contribution month
                }
                else
                {
                    // Check if the contribution is in a new month
                    if (currentMonth == member.ContributionMonths + 1 ||
                        (member.ContributionMonths == 12 && currentMonth == 1)) // Handles Dec -> Jan transition
                    {
                        member.ContributionMonthsCount += 1;
                        member.ContributionMonths = currentMonth;
                    }
                }

                // Add the contribution
                var contribution = new Contribution
                {
                    MemberId = memberId,
                    Amount = amount,
                    Type = type,
                    ContributionDate = currentDate
                };
                _context.Contributions.Add(contribution);

                // Update total contributions
                member.TotalContribution += amount;

                _context.Members.Update(member);

                // Update or create Benefit
                if (member.Benefit != null)
                {
                    var benefit = await _context.Benefits.FirstOrDefaultAsync(x => x.MemberId == member.MemberId);
                    benefit.Amount = _benefitCalculation.CalculateBenefit(member.TotalContribution);
                    benefit.CalculationDate = currentDate;
                    _context.Benefits.Update(benefit);
                }
                else
                {
                    var newBenefit = new Benefit
                    {
                        MemberId = memberId,
                        Amount = _benefitCalculation.CalculateBenefit(member.TotalContribution),
                        CalculationDate = currentDate,
                        EligibilityStatus = _benefitCalculation.CheckBenefitEligibility(member.TotalContribution, member.ContributionMonthsCount)
                    };
                    if (newBenefit.EligibilityStatus == true)
                    {
                        _context.Benefits.Add(newBenefit);
                    }
                      
                }

                // Save changes
                await _context.SaveChangesAsync();
                transaction.Commit();

                return "Contribution processed successfully.";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return ex.Message;
            }
        }


    }
}
