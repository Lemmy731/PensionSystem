using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.Entity
{
    public class Member
    {
        //member entity
        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        public decimal TotalContribution { get; set; }

        public List<Contribution> Contributions { get; set; } 
        public Benefit Benefit { get; set; }
    }
}
