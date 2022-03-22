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
        [FileSizeWeightValidation(maxWeightOnMB: 4)]
        [TypeOfFileValidation(typeOfFyleGroup: TypeOfFyleGroup.Image)]
        public IFormFile Image { get; set; }
    }
}
