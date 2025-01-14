using Microsoft.EntityFrameworkCore;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories
{
    public class ArtistAlbumRepository:IArtistAlbumRepository
    {
        private ApplicationDbContext _db;
        private IArtistRepository _artistRepository;
        private IAlbumRepository _albumRepository;
        public ArtistAlbumRepository(ApplicationDbContext db, IArtistRepository artistRepository, IAlbumRepository albumRepository)
        {
            _db = db;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
        }

        public OperationResult AssignArtistToAlbum(int artistId, int albumId)
        {
            //get the artist from db
            //get the album from db
            //find entry that contains both
            //if not already exists, create new entry
            //else already exists
            //return success or failure
            throw new NotImplementedException();
        }

        public OperationResult RemoveArtistFromAlbum(int artistId, int albumId)
        {
            //get the artist from db
            //get the album from db
            //find entry that contains both
            //if exists, remove
            //return success or failure
            throw new NotImplementedException();
        }

        private async Task <ArtistAlbumJunction> GetJunction(int artistId, int albumId)
        {
            //find entry that contains both
            ArtistAlbumJunction junction = await _db.ArtistAlbumJunctions.Where(x=>x.ArtistId == artistId && x.MusicRecordId==albumId).FirstOrDefaultAsync();
            if (junction == null) return null;
            return junction;
        }
    }
}
