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
    public class GenerateStatement: IGenerateStatement
    {
        private readonly AppDbContext _context;
        private readonly IContributionStatement _contributionStatement;

        public GenerateStatement(AppDbContext context, IContributionStatement contributionStatement)
        {
            _context = context;
            _contributionStatement = contributionStatement; 
        }

        public void GenerateAllStatements()
        {
            var members = _context.Members.Select(m => m.MemberId).ToList();
            List<string> contributions = new List<string>();    

            foreach (var memberId in members)
            {
                string statement = _contributionStatement.GenerateContributionStatement(memberId);
                contributions.Add(statement);       
                // Save statement
            }
        }

    }

}
