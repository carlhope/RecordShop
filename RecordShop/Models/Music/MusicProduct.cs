using RecordShop.Common.Enums;
using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Models.Music
{
    public class MusicProduct:IEntity
    {
        public int Id { get; set; }
        public DateOnly ReleaseDate { get; set; }
       
        public int MusicAlbumId { get; set; }
        public AlbumMediaType MediaType { get; set; }
        //navigation properties
        public Album? MusicAlbum { get; set; }

        
      
    }
}
