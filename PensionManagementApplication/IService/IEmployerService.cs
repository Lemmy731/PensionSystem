using PensionManagementDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementApplication.IService
{
    public interface IEmployerService
    {
        Task<string> Create(EmployerDto employerDto);
    }
}
