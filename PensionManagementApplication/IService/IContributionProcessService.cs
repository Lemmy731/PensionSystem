using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementApplication.IService
{
    public interface IContributionProcessService
    {
        Task<string> ProcessContribution(int memberId, decimal amount, ContributionType type);
    }
}
