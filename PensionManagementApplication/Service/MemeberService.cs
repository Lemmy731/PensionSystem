using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PensionManagementApplication.IService;
using PensionManagementDomain.DTO;
using PensionManagementDomain.Entity;
using PensionManagementInfrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementApplication.Service
{
    //member service
    public class MemeberService: IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILogger<MemeberService> _logger;

        public MemeberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;   
        }

        public async Task<string> Create(MemeberDto memberDto)
        {
            try
            {

                if (memberDto != null)
                {
                    var result = await _memberRepository.Create(memberDto); 
                    if (result.Contains("user added successfully"))
                    {
                        return "user created";
                    }
                    return "user not found";
                 
                }
                return "user not found";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.Message;
            }
        }

        public async Task<string> Get(int id)
        {
            try
            {
                var user = await _memberRepository.Get(id);
                if (user == "user do not exist")
                {
                    return "user not found";
                }
                return $"{user}";
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return ex.Message;
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var user = await _memberRepository.Delete(id);
                if (user == "user do not exist")
                {
                    return "user not found";
                }
                return "user deleted";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.Message;
            }
    
        }

        public async Task<string> Update(MemeberDto memberDto)
        {
            try
            {
                var user = await _memberRepository.Update(memberDto);
                if (user == "user do not exist")
                {
                    return "user not found";
                }
                return "member was updated";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.Message;
            }
           
            
        }

    }
}
