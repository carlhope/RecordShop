using RecordShop.DataAccess.Interfaces;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Models.Inventory
{
    public class InventoryItem:IEntity
    {
        public int Id { get; set; }
        public int MusicProductId {  get; set; }
        
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //navigation properties
        public MusicProduct? MusicProduct { get; set; }
    }
}
