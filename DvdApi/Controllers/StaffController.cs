using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace DvdApi.Controllers
{
    [ApiController]
    [Route("dvd/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Staff>>> GetStaff()
        {
            return Ok(await _staffService.GetAllStaffAsync());
        }
    }
}
