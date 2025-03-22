using AutoMapper;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services
{
    public class ArtistService:GenericService<Artist, ArtistReadDto, ArtistWriteDto>,IArtistService
    {
        public IMapper _mapper;
        public IArtistRepository _repo;

        public ArtistService(IMapper mapper, IArtistRepository repo) : base(mapper, repo)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ArtistReadDto>? GetByArtistName(string name)
        {
            var result = await _repo.GetByArtistName(name);
            var mapped = _mapper.Map<ArtistReadDto>(result);
            return mapped;
        }
    }
}
