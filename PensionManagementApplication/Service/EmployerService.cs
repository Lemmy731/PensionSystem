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
    //employer service
    public class EmployerService: IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly ILogger<MemeberService> _logger;

        public EmployerService(IEmployerRepository employerRepository, ILogger<MemeberService> logger )
        {
            _employerRepository = employerRepository;
            _logger = logger;
        }

        public async Task<string> Create(EmployerDto employerDto)
        {
            try
            {
                var user = await _employerRepository.Create(employerDto);
                if (user == "user created")
                {
                    return "user created successfully";
                }
                return "user already exist with this email";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.Message;  
            }
        }
    }
}
