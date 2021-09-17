using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Bussiness.DTOs
{
    public class PaginateDTO<T> where T: class
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int NumberOfRecords { get; set; }
        public List<T> Records { get; set; }

    }
}
