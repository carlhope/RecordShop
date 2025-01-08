namespace RecordShop.Common.Dto.Music
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ArtistAlbumJunctionDto> Artist { get; set; }
    }
}