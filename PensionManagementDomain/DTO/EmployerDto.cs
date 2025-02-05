using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.DTO
{
     public class EmployerDto
    {
        //employer dto
        [Required(ErrorMessage = "Company name is required.")]
        [RegularExpression(@"^[a-zA-Z0-9\s&.,'-]+$", ErrorMessage = "Company name contains invalid characters.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Registration number is required.")]
        [RegularExpression(@"^RC \d{5}$", ErrorMessage = "Registration number must be in the format 'RC 95673'.")]
        public string RegistrationNumber { get; set; }
    }
}
