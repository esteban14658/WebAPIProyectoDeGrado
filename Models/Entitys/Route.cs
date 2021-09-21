using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace PG.Models.Entitys
{
    public class Route
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CollectionPoint> CollectionPoints { get; set; }
        public Comment Comment { get; set; }
        [ForeignKey("Recycler")]
        public int RecyclerId { get; set; }

    }
}
