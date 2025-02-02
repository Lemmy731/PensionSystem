using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementDomain.Entity
{
    public class Employer
    {
        //employer entity
        [Key]
        public int EmployerId { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; } 
        public bool IsActive { get; set; } = true; 
    }
}
