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

        // GET api/inventory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        // POST api/inventory
        [HttpPost]
        public async Task<ActionResult<Inventory>> CreateInventory([FromBody] Inventory inventory)
        {
            var createdInventory = await _inventoryService.AddInventoryAsync(inventory);
            if (createdInventory == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetInventory), new { id = createdInventory.InventoryId }, createdInventory);
        }

        [HttpPut]
        public async Task<ActionResult<Inventory>> UpdateInventory(int id, [FromBody] Inventory inventory)
        {
            if (id != inventory.InventoryId)
            {
                return BadRequest();
            }

            var updatedInventory = await _inventoryService.UpdateInventoryAsync(inventory);
            if (updatedInventory == null)
            {
                return NotFound();
            }

            return Ok(updatedInventory);
        }

        // DELETE api/inventory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var result = await _inventoryService.DeleteInventoryAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }



    }
}