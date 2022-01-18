namespace WebAPIProyectoDeGrado.DTOs
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
        public AddressDTO Address { get; set; }
        public UserDTO User { get; set; }
    }
}
