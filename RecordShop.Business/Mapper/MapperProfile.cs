using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace RecordShop.Business.Mapper
{
    internal class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<MusicProduct, MusicProductDto>().ReverseMap();
            CreateMap<Album, AlbumDto>().ReverseMap();
            CreateMap<Artist, ArtistDto>().ReverseMap();
        }
    }
}
