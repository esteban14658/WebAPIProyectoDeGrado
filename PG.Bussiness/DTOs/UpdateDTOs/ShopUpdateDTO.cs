using Microsoft.AspNetCore.Http;
using PG.Bussiness.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Bussiness.DTOs.UpdateDTOs
{
    public class ShopUpdateDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
    }
}
