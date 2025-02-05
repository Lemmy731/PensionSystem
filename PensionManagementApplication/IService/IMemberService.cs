using PensionManagementDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementApplication.IService
{
    public interface IMemberService
    {
        Task<string> Create(MemeberDto memberDto);
        Task<string> Get(int id);
        Task<string> Delete(int id);
        Task<string> Update(MemeberDto memberDto);
    }
}
