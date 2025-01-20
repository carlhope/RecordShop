using Microsoft.AspNetCore.Mvc;
using RecordShop.Business.Services;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Inventory;
using RecordShop.DataAccess.Models.Inventory;

namespace RecordShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : GenericController<InventoryItem, InventoryItemReadDto>
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService) : base(inventoryService)
        {
           
            _inventoryService = inventoryService;
            
        }
        [HttpGet("stock")]
        public async Task<IActionResult> GetAllInStock()
        {
            List<InventoryItemReadDto>? stock = await _inventoryService.GetAllInStock();
            if (stock != null)
            {
                return Ok(stock);
            }
            return BadRequest();
        }
    }
}
