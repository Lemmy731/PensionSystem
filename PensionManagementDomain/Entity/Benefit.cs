using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.Entity
{
    public class Benefit
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; } // Foreign key to Member entity
        public BenefitType Type { get; set; } // Enum for benefit types
        public DateTime CalculationDate { get; set; } = DateTime.UtcNow; // When the benefit was calculated
        public bool EligibilityStatus { get; set; } // Is member eligible for benefit?
        public decimal Amount { get; set; } // Benefit amount

        public Member Member { get; set; } // Navigation property
    }

    public enum BenefitType
    {
        Pension,
        Withdrawal,
        Other
    }
}

