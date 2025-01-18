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
    public class ArtistAlbumService:GenericService<ArtistAlbumJunction, ArtistAlbumJunctionDto>, IArtistAlbumService
    {
        public IMapper _mapper;
        public IArtistAlbumRepository _repo;

        public ArtistAlbumService(IMapper mapper, IArtistAlbumRepository repo) : base(mapper, repo)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
