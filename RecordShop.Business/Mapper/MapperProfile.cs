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
            //read
            CreateMap<MusicProduct, MusicProductReadDto>().ReverseMap();
            CreateMap<Album, AlbumReadDto>().ReverseMap();
            CreateMap<Artist, ArtistReadDto>().ReverseMap();
            CreateMap<AlbumGenre, AlbumGenreReadDto>().ReverseMap();
            CreateMap<InventoryItem, InventoryItemReadDto>().ReverseMap();
            CreateMap<ArtistAlbumJunction, ArtistAlbumJunctionReadDto>().ReverseMap();

            //write
            CreateMap<MusicProduct, MusicProductWriteDto>().ReverseMap();
            CreateMap<Album, AlbumWriteDto>().ReverseMap();
            CreateMap<Artist, ArtistWriteDto>().ReverseMap();
            CreateMap<AlbumGenre, AlbumGenreWriteDto>().ReverseMap();
            CreateMap<InventoryItem, InventoryItemWriteDto>().ReverseMap();
            CreateMap<ArtistAlbumJunction, ArtistAlbumJunctionWriteDto>().ReverseMap();
        }
    }
}
