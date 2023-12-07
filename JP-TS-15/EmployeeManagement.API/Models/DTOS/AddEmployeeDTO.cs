using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models.DTOS
{
    public class AddEmployeeDTO
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
