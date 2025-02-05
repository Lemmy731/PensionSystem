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
    public class ContributionStatement: IContributionStatement
    {
        private readonly AppDbContext _context;
        public ContributionStatement(AppDbContext context)
        {
                _context = context;
        }
        //list of  member contribution
        public List<Contribution> GetMemberContributions(int memberId)
        {
            return _context.Contributions
                .Where(c => c.MemberId == memberId)
                .OrderByDescending(c => c.ContributionDate)
                .ToList();
        }

        public string GenerateContributionStatement(int memberId)
        {
            var contributions = GetMemberContributions(memberId);
            if (!contributions.Any()) return "No contributions found.";

            var statement = new StringBuilder();
            statement.AppendLine($"Contribution Statement for Member ID: {memberId}");
            statement.AppendLine("--------------------------------------------------");
            foreach (var c in contributions)
            {
                statement.AppendLine($"{c.ContributionDate:yyyy-MM-dd} | {c.Type} | Amount: {c.Amount:C}");
            }
            statement.AppendLine($"Total Contribution: {_context.Members.Find(memberId).TotalContribution:C}");
            return statement.ToString();
        }

    }
}
