using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG.Models.Entitys
{
    [Table(name: "comment")]
    public class Comment
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "description")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
    }
}
