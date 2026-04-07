using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactManagementSystem.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }

        public long MobileNo { get; set; }

        public string Designation { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        // 🔥 CRITICAL FIX
        [BindNever]
        public string CompanyName { get; set; }

        [BindNever]
        public string DepartmentName { get; set; }
    }
}