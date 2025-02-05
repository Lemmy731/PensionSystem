//using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionManagementApplication.IService;
using PensionManagementDomain.DTO;
using ApiVersion = Asp.Versioning.ApiVersion;

namespace PensionManagementPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]MemeberDto memberDto)
        {
            try
            {
                if (memberDto != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = await _memberService.Create(memberDto);
                        if (result == "user created")
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

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = await _memberService.Get(id);
                        if (result == "user do not exist")
                            return BadRequest(result);
                        else
                        {
                            return Ok(result);
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = await _memberService.Delete(id);
                        if (result == "user deleted")
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

        [HttpPut]
        public async Task<IActionResult> Update(MemeberDto memberDto)
        {
            try
            {
                if (memberDto != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = await _memberService.Update(memberDto);
                        if (result == "member was updated")
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
