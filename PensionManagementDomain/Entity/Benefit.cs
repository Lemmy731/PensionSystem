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
        //benefit entity
        [Key]
        public int BenefitId { get; set; }
        public int MemberId { get; set; } 
        public BenefitType Type { get; set; } 
        public DateTime CalculationDate { get; set; } = DateTime.Now; 
        public bool EligibilityStatus { get; set; }
        public decimal Amount { get; set; } 

        public Member Member { get; set; } 
    }

    public enum BenefitType
    {
        Monthly,
        LumpSum
    }
}

