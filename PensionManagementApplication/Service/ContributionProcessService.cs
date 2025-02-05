using Microsoft.Extensions.Logging;
using PensionManagementApplication.IService;
using PensionManagementDomain.DTO;
using PensionManagementDomain.Entity;
using PensionManagementInfrastructure.contribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementApplication.Service
{
    //process contribution 
    public class ContributionProcessService: IContributionProcessService
    {
    
        private readonly IContributionProcess _contributionProcess;
        private readonly ILogger<ContributionProcessService> _logger;

        public ContributionProcessService(IContributionProcess contributionProcess, ILogger<ContributionProcessService> logger)
        {
            _contributionProcess = contributionProcess;
            _logger = logger;
        }

        public async Task<string> ProcessContribution(int memberId, decimal amount, ContributionType type)
        {
            try
            {
                var response = await _contributionProcess.ProcessContribution(memberId, amount, type);
                if (response == "Contribution processed successfully.")
                {
                    return response;
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.Message;
            }
        }
    }
}
