using PensionManagementDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.IRepository
{
    public interface IEmployerRepository
    {
        Task<string> Create(EmployerDto employerDto);
    }
}
