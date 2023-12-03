using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models.DTOS
{
    public class CreateCompanyDTO
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
