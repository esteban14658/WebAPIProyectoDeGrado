using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG.Models.Entitys
{
    [Table(name: "codes")]
    public class Code
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "code")]
        public string UserCode { get; set; }
        [Column(name: "date")]
        public DateTime Date { get; set; }

    }
}
