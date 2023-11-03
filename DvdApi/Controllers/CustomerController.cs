using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace DvdApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = await _customerService.AddCustomerAsync(customer).ConfigureAwait(false);
            if (createdCustomer == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.CustomerId }, createdCustomer);
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            var existingCustomer = await _customerService.GetCustomerAsync(id);
            if (existingCustomer == null)
            {
                return NotFound(); 
            }

            await _customerService.UpdateCustomerAsync(id, customer);

            return NoContent();
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var existingCustomer = await _customerService.GetCustomerAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            await _customerService.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}

         

