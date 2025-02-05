using PensionManagementDomain.DTO;
using PensionManagementDomain.Entity;
using PensionManagementInfrastructure.DataAccess;
using PensionManagementInfrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.Repository
{
    public class EmployerRepository: IEmployerRepository
    {
        private readonly AppDbContext _context;

        public EmployerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(EmployerDto employerDto)
        {
            var user = await _context.Employers.FindAsync(employerDto.RegistrationNumber);
            if (user != null)
            {
                return "user already exist with this email";
            }

            Employer entity = new Employer()
            {
                CompanyName = employerDto.CompanyName,
                RegistrationNumber = employerDto.RegistrationNumber
            };

            await _context.Employers.AddAsync(entity);
            _context.SaveChanges();

            return "user created";
        }
    }
}
