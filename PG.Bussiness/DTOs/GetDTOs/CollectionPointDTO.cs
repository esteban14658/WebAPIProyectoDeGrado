using System;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CollectionPointDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string TypeOfMaterial { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public bool CommentState { get; set; }
        public AddressDto Address { get; set; }
        public int Resident { get; set; }
        public int RouteId { get; set; }
    }
}
