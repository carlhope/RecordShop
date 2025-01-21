using RecordShop.Common.Dto.Inventory;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Inventory;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services.IServices
{
    public interface IArtistService:IGenericService<Artist, ArtistReadDto, ArtistWriteDto>
    {
    }
}
