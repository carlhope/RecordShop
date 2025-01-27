using AutoMapper;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories.IRepository;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services
{
    public class GenreService:GenericService<AlbumGenre, AlbumGenreReadDto, AlbumGenreWriteDto>
    {
        public IMapper _mapper;
        public IGenericRepository<AlbumGenre> _genreRepository;

        public GenreService(IMapper mapper, IGenericRepository<AlbumGenre> genreRepository) : base(mapper, genreRepository)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
    }
}
