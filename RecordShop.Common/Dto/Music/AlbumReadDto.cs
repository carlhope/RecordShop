

namespace RecordShop.Common.Dto.Music
{
    public class AlbumReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //navigation properties
        public List<ArtistAlbumJunctionReadDto> ArtistJunction { get; set; } = new List<ArtistAlbumJunctionReadDto>();
        public List<AlbumGenreReadDto> Genres { get; set; }
    }
}