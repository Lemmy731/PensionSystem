//using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionManagementApplication.IService;
using PensionManagementDomain.DTO;
using PensionManagementDomain.Entity;
using ApiVersion = Asp.Versioning.ApiVersion;

namespace PensionManagementPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionProcessController : ControllerBase
    {
        private readonly IContributionProcessService _contributionProcessService;
        public ContributionProcessController(IContributionProcessService contributionProcessService)
        {
            _contributionProcessService = contributionProcessService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessContribution([FromBody]ContributionDto contributionDto)
        {
            try
            {
                if (contributionDto != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = await _contributionProcessService.ProcessContribution(contributionDto.MemberId, contributionDto.Amount, contributionDto.Type);
                        if (result == "Contribution processed successfully.")
                            return Ok(result);
                        else
                        {
                            return BadRequest(result);
                        }

                    }
                    return BadRequest("invalid data");
                }
                return BadRequest("no data");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
