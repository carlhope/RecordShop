using RecordShop.Common.Models;
using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services.IServices
{
    public interface IGenericService<in T, DTO> where T : class, IEntity where DTO : class
    {
         Task<IEnumerable<DTO>> GetAllAsync();
         Task<DTO> GetByIdAsync(int id);
         Task<OperationResult> CreateAsync(DTO dto);
         Task<OperationResult> UpdateAsync(int id, DTO dto);
         Task<OperationResult> DeleteAsync(int id);
    }
}
