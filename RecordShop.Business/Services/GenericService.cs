using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Interfaces;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services
{
    public class GenericService<T, ReadDTO,WriteDTO> : IGenericService<T, ReadDTO, WriteDTO> where T : class, IEntity where ReadDTO : class where WriteDTO : class
    {
        public IMapper _mapper;
        public IGenericRepository<T> _repo;

        public GenericService(IMapper mapper, IGenericRepository<T> repo)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public virtual async Task<OperationResult> CreateAsync(WriteDTO dto)
        {
            OperationResult result = new();
            try
            {
                T entity = _mapper.Map<T>(dto);
                result = await _repo.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
        
        public virtual async Task<OperationResult> DeleteAsync([FromBody] int id)
        {
            OperationResult result = new();
            try
            {
                await _repo.DeleteAsync(id);
                result.IsSuccess = true;
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.ToString();
            }
            return result;
        }

        public virtual async Task<IEnumerable<ReadDTO>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var results = _mapper.Map<List<ReadDTO>>(data);
            return results;
        }

        public virtual async Task<ReadDTO> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            var results = _mapper.Map<ReadDTO>(data);
            return results;
        }

        public virtual async Task<OperationResult> UpdateAsync(int id, WriteDTO dto)
        {
            OperationResult result = new OperationResult();
            try
            {
                T entity = _mapper.Map<T>(dto);
                result = await _repo.UpdateAsync(id, entity);
            }
            catch (Exception ex)
            {
                result.Message = ex.ToString();
            }
            return result;
        }
    }
}
