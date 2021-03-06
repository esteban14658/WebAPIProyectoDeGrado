using System.ComponentModel.DataAnnotations;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateCollectionPointDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string TypeOfMaterial { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public bool CommentState { get; set; }
        [Required]
        public CreateAddressDto Address { get; set; }
        [Required]
        public int Resident { get; set; }
    }
}
