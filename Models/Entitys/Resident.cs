using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProyectoDeGrado.Entitys
{
    [Table(name: "resident")]
    public class Resident
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "name")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Name { get; set; }
        [Column(name: "last_name")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string LastName { get; set; }
        [Column(name: "phone")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Phone { get; set; }
        public List<Address> AddressList { get; set; }
        [Column(name: "user_id")]
        public User User { get; set; }
    }
}
