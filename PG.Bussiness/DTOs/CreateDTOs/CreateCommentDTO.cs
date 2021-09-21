using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Bussiness.DTOs.CreateDTOs
{
    public class CreateCommentDTO
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
    }
}
