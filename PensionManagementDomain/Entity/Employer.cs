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
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; } // Business Registration Number
        public bool IsActive { get; set; } = true; // Employer status (Active/Inactive)
    }
}
