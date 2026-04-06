using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(1000, 1000000)]
        public int Salary { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}