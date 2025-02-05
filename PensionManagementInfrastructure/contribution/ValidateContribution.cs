using Microsoft.EntityFrameworkCore;
using PensionManagementDomain.Entity;
using PensionManagementInfrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.contribution
{
    public class ValidateContribution: IValidateContribution
    {
        private readonly AppDbContext _context;

        public ValidateContribution(AppDbContext context)
        {
            _context = context;   
        }
        public void ValidateMonthlyContributions()
        {
            var invalidContributions = _context.Contributions
                .GroupBy(c => new { c.MemberId, c.ContributionDate.Month, c.ContributionDate.Year })
                .Where(g => g.Count(c => c.Type == ContributionType.Monthly) > 1)
                .SelectMany(g => g);

            foreach (var contribution in invalidContributions)
            {
                _context.Contributions.Remove(contribution);
            }
            _context.SaveChanges();
        }

    }
}
