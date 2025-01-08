using Microsoft.EntityFrameworkCore;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Interfaces;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();

        }
        public virtual async Task<OperationResult> CreateAsync(T source)
        {
            OperationResult result = new OperationResult();
       
          
            try
            {
                if (source != null && MyValidator<T>.IsValid(source))
                {
                    _dbSet.Add(source);
                    await _db.SaveChangesAsync();
                    result.IsSuccess = true;
                    result.Message = "Item added successfully";
                }
                else
                {

                    result.Message = "Item is null";
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = GetByIdAsync(id).Result;
            if (entity != null)
            {

                _dbSet.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<OperationResult> UpdateAsync(int id, T source)
        {
            OperationResult result = new OperationResult();
            try
            {
                var itemToUpdate = _dbSet.Find(id);
                if (itemToUpdate!=null && MyValidator<T>.IsValid(source))
                {
                    var properties = typeof(T).GetProperties();
                    foreach(var property in properties)
                    {
                        if (property.CanWrite && property.Name!="Id")
                        {
                            var newValue = property.GetValue(source);
                            property.SetValue(itemToUpdate, newValue);
                        }
                    }
                    await _db.SaveChangesAsync();
                    result.Message = "Item updated";
                    result.IsSuccess = true;
                }
                else
                {
                    result.Message = "Invalid data";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }
    }
}
