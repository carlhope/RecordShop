using RecordShop.Common.Enums;

namespace RecordShop.DataAccess.Models.Music
{
    public class AlbumGenreDto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public Genre Genre { get; set; }
    }
}
