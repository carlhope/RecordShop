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
    public class ArtistAlbumRepository:GenericRepository<ArtistAlbumJunction>,IArtistAlbumRepository
    {
        private ApplicationDbContext _db;
        private IArtistRepository _artistRepository;
        private IAlbumRepository _albumRepository;
        public ArtistAlbumRepository(ApplicationDbContext db, IArtistRepository artistRepository, IAlbumRepository albumRepository):base(db)
        {
            _db = db;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
        }

        public async Task<OperationResult> AssignArtistToAlbum(int artistId, int albumId)
        {
            OperationResult result = new OperationResult();
            var junction = GetJunction(artistId, albumId);
            if (junction != null)
            {
                result.Message = "Junction entry already exists";
                return result;
            }
            try
            {
                ArtistAlbumJunction artistAlbum = new ArtistAlbumJunction()
                {
                    ArtistId = artistId,
                    MusicRecordId = albumId,
                };
                _db.ArtistAlbumJunctions.Add(artistAlbum);
                await _db.SaveChangesAsync();
                result.Message = "Success";
                result.IsSuccess = true;
                return result;

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

                //get the artist from db
                //get the album from db
                //find entry that contains both
                //if not already exists, create new entry
                //else already exists
                //return success or failure
                throw new NotImplementedException();
        }

        public async Task<OperationResult> RemoveArtistFromAlbum(int artistId, int albumId)
        {
            OperationResult result = new OperationResult();
            var junction = await GetJunction(artistId, albumId);
            if (junction == null)
            {
                result.Message = "Junction entry not found";
                return result;
            }
            try
            {
                _db.ArtistAlbumJunctions.Remove(junction);
                result.IsSuccess = true;
                result.Message = "Junction entry removed";
                return result;
            }
            catch (Exception ex) 
            {
                result.Message = ex.Message;
                return result;
            }
           
        }

        private async Task <ArtistAlbumJunction> GetJunction(int artistId, int albumId)
        {
            //find entry that contains both
             return await _db.ArtistAlbumJunctions.Where(x=>x.ArtistId == artistId && x.MusicRecordId==albumId).FirstOrDefaultAsync();
          
            
        }
    }
}
