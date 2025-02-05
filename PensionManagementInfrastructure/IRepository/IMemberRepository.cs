using PensionManagementDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.IRepository
{
    public interface IMemberRepository
    {
        Task<string> Create(MemeberDto memberDto);
        Task<string> Get(int id);
        Task<string> Delete(int id);
        Task<string> Update(MemeberDto memberDto);

    }
}
