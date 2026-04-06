using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
