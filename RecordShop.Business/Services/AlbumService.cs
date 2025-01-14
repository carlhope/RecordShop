﻿using AutoMapper;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.Common.Enums;
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
        public async Task<List<AlbumDto>?> GetAllByArtist(int id)
        {
           var result = await _albumRepository.GetAllByArtist(id);
            var mapped = _mapper.Map<List<AlbumDto>>(result);
            return mapped;
        }
        public async Task<List<AlbumDto>?> GetAllByGenre(Genre genre)
        {
            var result = await _albumRepository.GetAllByGenre(genre);
            var mapped = _mapper.Map<List<AlbumDto>>(result);
            return mapped;
        }
        public async Task<AlbumDto>? GetByAlbumName(string name)
        {
            var result = await _albumRepository.GetByAlbumName(name);
            var mapped = _mapper.Map<AlbumDto>(result);
            return mapped;
        }
    }
}
