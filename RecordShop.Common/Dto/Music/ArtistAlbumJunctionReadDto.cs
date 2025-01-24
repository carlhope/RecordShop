namespace RecordShop.Common.Dto.Music
{
    public class ArtistAlbumJunctionReadDto
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        //navigation properties
        public ArtistReadDto Artist { get; set; }
        public AlbumReadDto Album { get; set; }

    }
}