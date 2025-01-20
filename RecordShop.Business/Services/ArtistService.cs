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
    public class ArtistService:GenericService<Artist, ArtistReadDto>,IArtistService
    {
        public IMapper _mapper;
        public IArtistRepository _repo;

        public ArtistService(IMapper mapper, IArtistRepository repo) : base(mapper, repo)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
