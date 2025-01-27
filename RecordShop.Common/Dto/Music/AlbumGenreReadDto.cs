using RecordShop.Common.Enums;

namespace RecordShop.Common.Dto.Music
{
    public class AlbumGenreReadDto
    {
        public int Id { get; set; }
        public Genre Genre { get; set; }
        public int AlbumId { get; set; }
        //navigation properties
        public AlbumReadDto Album { get; set; }
    }
}
