

namespace RecordShop.Common.Dto.Music
{
    public class AlbumWriteDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AlbumGenreWriteDto>? Genres { get; set; }
    }
}