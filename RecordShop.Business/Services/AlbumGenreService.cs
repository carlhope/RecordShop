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
    public class AlbumGenreService : GenericService<AlbumGenre, AlbumGenreReadDto, AlbumGenreWriteDto>, IAlbumGenreService
    {
        public new IMapper _mapper;
        public new IAlbumGenreRepository _repo;
        public AlbumGenreService(IMapper mapper, IAlbumGenreRepository repo) : base(mapper, repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<AlbumGenreReadDto?> GetByName(string name)
        {
            var genre = await _repo.GetByGenreName(name);
            if (genre == null) return null;
            return _mapper.Map<AlbumGenreReadDto>(genre);
        }
    }
}
