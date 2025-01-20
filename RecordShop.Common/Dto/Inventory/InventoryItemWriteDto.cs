﻿using RecordShop.Common.Dto.Music;
using RecordShop.Common.Enums;

namespace RecordShop.Common.Dto.Inventory
{
    public class InventoryItemWriteDto
    {
        public int Id { get; set; }
        public int MusicProductId {  get; set; }
        
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //navigation properties
        public MusicProductReadDto? MusicProduct { get; set; }
    }
}
