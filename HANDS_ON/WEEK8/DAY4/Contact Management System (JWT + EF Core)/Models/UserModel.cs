using System.ComponentModel.DataAnnotations;

namespace Contact_Management_System__JWT___EF_Core_.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }  // Admin or User
    }
}
