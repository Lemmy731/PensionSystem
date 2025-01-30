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
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; } // Foreign key to Member entity
        public ContributionType Type { get; set; } // Enum for Monthly/Voluntary
        public decimal Amount { get; set; } // Amount should be > 0
        public DateTime ContributionDate { get; set; } // Date of contribution
        public string ReferenceNumber { get; set; } // Unique identifier
        public Member Member { get; set; } // Navigation property
    }

    public enum ContributionType
    {
        Monthly,
        Voluntary
    }

}

