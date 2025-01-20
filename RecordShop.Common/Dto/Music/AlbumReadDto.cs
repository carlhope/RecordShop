

namespace RecordShop.Common.Dto.Music
{
    public class AlbumReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //navigation properties
        public List<ArtistAlbumJunctionReadDto> Artist { get; set; } = [];
        public List<AlbumGenreReadDto> Genres { get; set; } = [];
    }
}