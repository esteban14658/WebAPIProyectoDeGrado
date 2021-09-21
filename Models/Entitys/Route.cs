using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace PG.Models.Entitys
{
    [Table(name: "route")]
    public class Route
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "start_date")]
        public DateTime StartDate { get; set; }
        [Column(name: "end_date")]
        public DateTime EndDate { get; set; }
        public List<CollectionPoint> CollectionPoints { get; set; }
        [Column(name: "comment_id")]
        public Comment Comment { get; set; }
        [Column(name: "recycler_id")]
        public Recycler Recycler { get; set; }

    }
}
