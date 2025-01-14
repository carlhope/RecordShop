﻿using AutoMapper;
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
    public class AlbumService:GenericService<Album, AlbumDto>, IAlbumService
    {
        public IMapper _mapper;
        public IAlbumRepository _albumRepository;

        public AlbumService(IMapper mapper, IAlbumRepository albumRepository) : base(mapper, albumRepository)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }
    }
}
