using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        public string StudentName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a course")]
        public int CourseId { get; set; }   

        public Course Course { get; set; }
    }
}