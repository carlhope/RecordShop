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
            CreateMap<MusicProduct, MusicProductDto>().ReverseMap();
            CreateMap<Album, AlbumDto>().ReverseMap();
            CreateMap<Artist, ArtistDto>().ReverseMap();
            CreateMap<AlbumGenre, AlbumGenreDto>().ReverseMap();
            CreateMap<InventoryItem, InventoryItemDto>().ReverseMap();
            CreateMap<ArtistAlbumJunction, ArtistAlbumJunctionDto>().ReverseMap();
        }
    }
}
