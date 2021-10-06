﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateCollectionPointDTO
    {
        [Required]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string TypeOfMaterial { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 35, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
        public Boolean State { get; set; }
        [Required]
        public CreateAddressDTO Address { get; set; }
    }
}
