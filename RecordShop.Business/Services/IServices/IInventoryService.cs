using RecordShop.Common.Dto.Inventory;
using RecordShop.DataAccess.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services.IServices
{
    public interface IInventoryService:IGenericService<InventoryItem, InventoryItemReadDto, InventoryItemWriteDto>
    {
        Task<List<InventoryItemReadDto>> GetAllInStock();
    }
}
