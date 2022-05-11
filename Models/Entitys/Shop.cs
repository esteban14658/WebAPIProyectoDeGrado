using Microsoft.EntityFrameworkCore;
using PG.Models.Entitys;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProyectoDeGrado.Entitys
{
    [Table(name: "shop")]
    [Index(nameof(Document), IsUnique = true)]
    public class Shop
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "name")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Name { get; set; }
        [Column(name: "document_type")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 15, ErrorMessage = "field {0} must be less than {1} characters")]
        public string DocumentType { get; set; }
        [Column(name: "document")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Document { get; set; }
        [Column(name: "phone")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Phone { get; set; }
        [Column(name: "image")]
        public string Image { get; set; }
        public List<Order> OrderList { get; set; }
        [Column(name: "address_id")]
        public Address Address { get; set; }
        [Column(name: "user_id")]
        public User User { get; set; }
    }
}
