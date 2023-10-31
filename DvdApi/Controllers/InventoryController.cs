using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace DvdApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }


        // GET: api/inventory
        [HttpGet]
        public async Task<ActionResult<List<Inventory>>> GetInventory()
        {
            return Ok(await _inventoryService.GetAllInventoryAsync());
        }
    }
}