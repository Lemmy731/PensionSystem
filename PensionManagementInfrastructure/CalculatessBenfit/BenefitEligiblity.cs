using Microsoft.EntityFrameworkCore;
using PensionManagementInfrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.CalculatessBenfit
{
    public class BenefitEligiblity: IBenefitEligiblity
    {
        private readonly AppDbContext _appDbContext;
        private readonly IBenefitCalculation _benefitCalculation;
        public BenefitEligiblity(AppDbContext appDbContext, IBenefitCalculation benefitCalculation)
        {
            _appDbContext = appDbContext; 
            _benefitCalculation = benefitCalculation;
        }
        //update benefit eligibility status

        public void UpdateBenefitEligibility()
        {
            var members = _appDbContext.Members.Include(m => m.Benefit).ToList();

            foreach (var member in members)
            {
                if (member.Benefit != null)
                {
                    member.Benefit.EligibilityStatus = _benefitCalculation.CheckBenefitEligibility(member.TotalContribution, member.ContributionMonthsCount);
                    if(member.Benefit.EligibilityStatus == true)
                    {
                        _appDbContext.Benefits.Update(member.Benefit);
                        _appDbContext.SaveChanges();
                    }
                    
                }
            }
            
        }
    }
}
