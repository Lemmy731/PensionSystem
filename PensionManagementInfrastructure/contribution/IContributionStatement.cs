using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.contribution
{
    public interface IContributionStatement
    {
        List<Contribution> GetMemberContributions(int memberId);
        string GenerateContributionStatement(int memberId);
    }
}
