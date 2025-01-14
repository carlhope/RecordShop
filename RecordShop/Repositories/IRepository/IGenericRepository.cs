using RecordShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<OperationResult> UpdateAsync(int id, T entity);
        public Task<bool> DeleteAsync(int id);
        public Task<T?> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<OperationResult> CreateAsync(T entity);
    }
}
