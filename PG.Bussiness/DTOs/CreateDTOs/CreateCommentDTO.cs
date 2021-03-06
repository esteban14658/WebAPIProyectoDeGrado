using System;
using System.ComponentModel.DataAnnotations;

namespace PG.Bussiness.DTOs.CreateDTOs
{
    public class CreateCommentDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
