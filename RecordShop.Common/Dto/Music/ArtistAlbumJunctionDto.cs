namespace RecordShop.Common.Dto.Music
{
    public class ArtistAlbumJunctionDto
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public ArtistDto? Artist { get; set; }
        public int MusicRecordId { get; set; }
        public AlbumDto? MusicRecord { get; set; }

    }
}