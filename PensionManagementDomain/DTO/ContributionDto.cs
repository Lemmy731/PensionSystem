using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.DTO
{
    public class ContributionDto
    {
        //contribution dto
        [Required(ErrorMessage = "Member ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Member ID must be a positive number.")]
        public int MemberId { get; set; }

        
        [Required(ErrorMessage = "Contribution type is required.")]
        public ContributionType Type { get; set; }

       [Required(ErrorMessage = "Amount is required.")]
       [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
       [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Amount must have at most 2 decimal places.")]
       public decimal Amount { get; set; }
    }
}
