using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Bussiness.DTOs
{
    class PaginateDTO<T> where T: class
    {
        public List<T> Registers { get; set; }

    }
}
