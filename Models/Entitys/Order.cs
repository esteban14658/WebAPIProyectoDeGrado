using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG.Models.Entitys
{
    [Table(name: "order")]
    [ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    public class Order
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "type_of_material")]
        public string TypeOfMaterial { get; set; }
        [Column(name: "price")]
        public long Price { get; set; }
        [Column(name: "shop_id")]
        [ForeignKey("Shop")]
        public int? ShopId { get; set; }

    }
}
