using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace DvdApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Staff>>> GetStaff()
        {
            return Ok(await _staffService.GetAllStaffAsync());
        }


        // GET api/actors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }


        // POST api/actors
        [HttpPost]
        public async Task<ActionResult<Staff>> CreateStaff([FromBody] Staff staff)
        {
            var createdStaff = await _staffService.AddStaffAsync(staff);
            if (createdStaff == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetStaff), new { id = createdStaff.StaffId }, createdStaff);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> UpdateStaff(int id, [FromBody] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            var updatedStaff = await _staffService.UpdateStaffAsync(id, staff);
            if (updatedStaff == null)
            {
                return NotFound();
            }

            return Ok(updatedStaff);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var result = await _staffService.DeleteStaffAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }


}
