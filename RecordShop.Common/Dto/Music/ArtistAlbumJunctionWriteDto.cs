using System.Text.Json.Serialization;

namespace RecordShop.Common.Dto.Music
{
    public class ArtistAlbumJunctionWriteDto
    {
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }

    }
}