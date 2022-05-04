using System;

namespace PG.Bussiness.DTOs.GetDTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
