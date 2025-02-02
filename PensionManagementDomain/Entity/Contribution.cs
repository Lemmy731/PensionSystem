using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.Entity
{
    public class Contribution
    {
        //contribution entity
        [Key]
        public int ContributionId { get; set; }
        public int MemberId { get; set; } 
        public ContributionType Type { get; set; } 
        public decimal Amount { get; set; }
        public DateTime ContributionDate { get; set; } 
        public string ReferenceNumber { get; set; } 

        public Member Member { get; set; } 
    }

    public enum ContributionType
    {
        Monthly,
        Voluntary
    }

}

