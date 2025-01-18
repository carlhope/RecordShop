using RecordShop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Common.Dto.Music
{
    public class MusicProductDto
    {
        public int Id { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int MusicAlbumId { get; set; }
        public AlbumMediaType MediaType { get; set; }
        //navigation properties
        public AlbumDto? MusicAlbum { get; set; }

        

    }
}
