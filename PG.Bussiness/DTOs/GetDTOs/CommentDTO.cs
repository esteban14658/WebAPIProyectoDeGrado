using System;

namespace PG.Bussiness.DTOs.GetDTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
