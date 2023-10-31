using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace DvdApi.Controllers
{

    [ApiController]
    [Route("dvd/[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }
        
    }
}

         

