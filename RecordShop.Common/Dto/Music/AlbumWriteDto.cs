

using System.Text.Json.Serialization;

namespace RecordShop.Common.Dto.Music
{
    public class AlbumWriteDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AlbumGenreWriteDto>? Genres { get; set; }
        [JsonPropertyName("artistJunction")]
        public List<ArtistAlbumJunctionWriteDto>? ArtistJunction { get; set; }
    }
}