using Microsoft.EntityFrameworkCore;
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
    public class MemberRepository : IMemberRepository
    {

        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
                _context = context;   
        }

        public async Task<string> Create(MemeberDto memberDto)
        {
            var user = await _context.Members.FindAsync(memberDto.Email);
            if (user != null)
            {
                return "user already exist with this email";
            }

            Member memberEntity = new Member()
            {
                FirstName = memberDto.FirstName,    
                LastName = memberDto.LastName,  
                Email = memberDto.Email,    
                PhoneNumber = memberDto.PhoneNumber,    
                Age = memberDto.Age,    
            };

    
            var userResponse = await _context.Members.AddAsync(memberEntity);
            var response = await _context.SaveChangesAsync();
            if (response > 0)
            {
                return "user added successfully";
            }
            return "unable to create user";
        }

        public async Task<string> Get(int id)
        {
            var user = await _context.Members.FindAsync(id);
            if (user == null)
            {
                return "user do not exist";
            }

            
                return $"{user}";
           
        }

        public async Task<string> Delete(int id)
        {
            var user = await _context.Members.FindAsync(id);
            if (user == null)
            {
                return "user do not exist";
            }

             _context.Members.Remove(user); 
            _context.SaveChanges(); 
            return "member deleted";
        }

        public async Task<string> Update(MemeberDto memberDto)
        {
            var user = await _context.Members.FirstOrDefaultAsync(x=> x.Email == memberDto.Email);
            if (user == null)
            {
                return "user do not exist";
            }
            if(memberDto.Email != null)
            {
                user.Email = memberDto.Email;
            }
            if (memberDto.FirstName != null)
            {
                user.FirstName = memberDto.FirstName;
            }
            if (memberDto.LastName != null)
            {
                user.LastName = memberDto.LastName;

            }
            if (memberDto.DateOfBirth != null)
            {
                user.DateOfBirth = memberDto.DateOfBirth;

            }
           _context.Members.Update(user); 
            _context.SaveChanges();
            return "member updated";
        }
    }
    
}
