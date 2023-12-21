using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
    }
}
