using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.CalculatessBenfit
{
    public interface IBenefitCalculation
    {
        decimal CalculateBenefit(decimal totalContribution);
        bool CheckBenefitEligibility(decimal totalContribution, int contributionMonthCount);
    }
}
