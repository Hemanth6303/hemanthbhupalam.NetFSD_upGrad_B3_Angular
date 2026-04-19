using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Contact_Management_System__JWT___EF_Core_.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Designation { get; set; }

        public int CompanyId { get; set; }

        [JsonIgnore]   // 🔥 IMPORTANT FIX
        public Company? Company { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]   // 🔥 IMPORTANT FIX
        public Department? Department { get; set; }
    }
}