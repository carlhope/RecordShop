using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Models.Music
{
    public class ArtistAlbumJunction:IEntity
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        
        public int MusicRecordId { get; set; }
        //navigation properties
        public Artist Artist { get; set; }
        public Album MusicRecord { get; set; }
    }
}
