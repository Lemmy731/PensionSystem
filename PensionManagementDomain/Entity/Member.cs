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
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        public decimal TotalContribution { get; set; }
        public int ContributionMonths { get; set; } = 0; // Track unique months
        public bool IsEligibleForBenefit { get; set; } = false; // Eligibility flag
        public int ContributionMonthsCount { get; set; } = 0;   //keep count of months contribution has been made

        public List<Contribution> Contributions { get; set; } 
        public Benefit Benefit { get; set; }
    }
}
