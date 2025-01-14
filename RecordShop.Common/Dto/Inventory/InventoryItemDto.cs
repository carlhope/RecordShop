using RecordShop.Common.Dto.Music;

namespace RecordShop.Common.Dto.Inventory
{
    public class InventoryItemDto
    {
        public int Id { get; set; }
        public int MusicProductId {  get; set; }
        public MusicProductDto? MusicProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
