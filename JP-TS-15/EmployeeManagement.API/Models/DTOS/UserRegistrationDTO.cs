using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models.DTOS
{
    public class UserRegistrationDTO
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
