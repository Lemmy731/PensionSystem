//using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionManagementApplication.IService;
using PensionManagementDomain.DTO;
using System.Drawing.Text;
using ApiVersion = Asp.Versioning.ApiVersion;

namespace PensionManagementPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EmployerDto employerDto)
        {
            try
            {
                if (employerDto != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = await _employerService.Create(employerDto);
                        if (result == "user created successfully")
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
