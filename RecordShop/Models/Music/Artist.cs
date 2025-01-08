using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Models.Music
{
    public class Artist:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ArtistAlbumJunction> MusicRecords { get; set; }
    }
}
