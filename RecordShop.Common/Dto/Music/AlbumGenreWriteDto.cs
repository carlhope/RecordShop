using RecordShop.Common.Enums;

namespace RecordShop.Common.Dto.Music
{
    public class AlbumGenreWriteDto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public Genre Genre { get; set; }

    }
}
