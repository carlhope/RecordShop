using AutoMapper;
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
    public class ArtistService:GenericService<Artist, ArtistDto>
    {
        public IMapper _mapper;
        public IGenericRepository<Artist> _repo;

        public ArtistService(IMapper mapper, IGenericRepository<Artist> repo) : base(mapper, repo)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
