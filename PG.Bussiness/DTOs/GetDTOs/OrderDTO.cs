namespace PG.Bussiness.DTOs.GetDTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string TypeOfMaterial { get; set; }
        public long Price { get; set; }
        public int ShopId { get; set; }
    }
}
