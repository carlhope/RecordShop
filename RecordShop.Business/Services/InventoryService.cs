using AutoMapper;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Inventory;
using RecordShop.DataAccess.Models.Inventory;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services
{
    public class InventoryService : GenericService<InventoryItem, InventoryItemReadDto>, IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IMapper mapper, IInventoryRepository inventoryRepository) : base(mapper, inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<List<InventoryItemReadDto>> GetAllInStock()
        {
            var data = await _inventoryRepository.GetAllInStock();
            return _mapper.Map<List<InventoryItemReadDto>>(data);
        }
    }
}
