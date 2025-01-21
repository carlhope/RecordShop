using AutoMapper;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services
{
    public class MusicProductService:GenericService<MusicProduct, MusicProductReadDto, MusicProductWriteDto>, IMusicProductService
    {
        public IMapper _mapper;
        public IMusicProductRepository _musicProductRepository;

        public MusicProductService(IMapper mapper, IMusicProductRepository musicProductRepository) : base(mapper, musicProductRepository)
        {
            _musicProductRepository = musicProductRepository;
            _mapper = mapper;
        }

        public async Task<Dictionary<AlbumReadDto, List<MusicProductReadDto>>?> GetAllByReleaseYear(int year)
        {
            var result = await _musicProductRepository.GetAllByReleaseYear(year);
            Dictionary<AlbumReadDto, List<MusicProductReadDto>> mapped = _mapper.Map<Dictionary<AlbumReadDto,List<MusicProductReadDto>>>(result);
            return mapped;
        }
    }
}
