using Microsoft.EntityFrameworkCore;
using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.CalculatessBenfit
{
    public class BenefitCalculation: IBenefitCalculation
    {
        public BenefitCalculation()
        {

        }

        public decimal CalculateBenefit(decimal totalContribution)
        {
            // 10% of total contribution as benefit
            return totalContribution * 0.10m;
        }

        //check member benefit eligibility 
        public bool CheckBenefitEligibility(decimal totalContribution, int contributionMonthCount)
        {
            //Minimum contribute and minimun  contribution period before benefit eligibility
          
            if (totalContribution >= 5000 && contributionMonthCount >= 24)
            {
                      return true;
            }
            return false;
        }
    }
}
