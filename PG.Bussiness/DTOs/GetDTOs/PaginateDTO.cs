using System.Collections.Generic;

namespace PG.Bussiness.DTOs
{
    public class PaginateDTO<T> where T : class
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int NumberOfRecords { get; set; }
        public List<T> Records { get; set; }

    }
}
