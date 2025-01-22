using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RecordShop.DataAccess.Models.Inventory;
using RecordShop.Common.Dto.Inventory;

namespace RecordShop.Business.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            //artistAlbumJunction
            CreateMap<ArtistAlbumJunction, ArtistAlbumJunctionReadDto>().ReverseMap();
            CreateMap<ArtistAlbumJunction, ArtistAlbumJunctionWriteDto>().ReverseMap();
            //music product
            CreateMap<MusicProduct, MusicProductReadDto>().ReverseMap();
            CreateMap<MusicProduct, MusicProductWriteDto>().ReverseMap();
            //album
            CreateMap<Album, AlbumReadDto>().ReverseMap();
            CreateMap<Album, AlbumWriteDto>().ReverseMap();
            //artist
            CreateMap<Artist, ArtistReadDto>().ReverseMap();
            CreateMap<Artist, ArtistWriteDto>().ReverseMap();
            //albumGenre
            CreateMap<AlbumGenre, AlbumGenreReadDto>().ReverseMap();
            CreateMap<AlbumGenre, AlbumGenreWriteDto>().ReverseMap();
            //inventory
            CreateMap<InventoryItem, InventoryItemReadDto>().ReverseMap();
            CreateMap<InventoryItem, InventoryItemWriteDto>().ReverseMap();
            






        }
    }
}
