using System.ComponentModel.DataAnnotations;

namespace PG.Bussiness.DTOs.UpdateDTOs
{
    public class ResidentUpdateDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Phone { get; set; }
    }
}
