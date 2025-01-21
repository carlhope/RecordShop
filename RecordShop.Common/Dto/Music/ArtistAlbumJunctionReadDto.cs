namespace RecordShop.Common.Dto.Music
{
    public class ArtistAlbumJunctionReadDto
    {
        public int Id { get; set; }
        //navigation properties
        public ArtistReadDto Artist { get; set; }
        public AlbumReadDto MusicRecord { get; set; }

    }
}