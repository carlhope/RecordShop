using RecordShop.Common.Models;
using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services.IServices
{
    public interface IGenericService<T, ReadDTO, WriteDTO> where T : class, IEntity where ReadDTO : class where WriteDTO : class
    {
         Task<IEnumerable<ReadDTO>> GetAllAsync();
         Task<ReadDTO> GetByIdAsync(int id);
         Task<OperationResult> CreateAsync(WriteDTO dto);
         Task<OperationResult> UpdateAsync(int id, WriteDTO dto);
         Task<OperationResult> DeleteAsync(int id);
    }
}
