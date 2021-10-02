namespace WebAPIProyectoDeGrado.DTOs
{
    public class RecyclerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public UserDTO User { get; set; }
    }
}
