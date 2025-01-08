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
    public class AlbumService:GenericService<Album, AlbumDto>
    {
        public IMapper _mapper;
        public IGenericRepository<Album> _repo;

        public AlbumService(IMapper mapper, IGenericRepository<Album> repo) : base(mapper, repo)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
