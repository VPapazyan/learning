using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entity_CodeFirst.DAL;
using System.Threading.Tasks;
using Entity_CodeFirst.Models;
using Entity_CodeFirst.Entities;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Entity_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult GetCustomersAsync()
        {
            return Ok(new CustomerService().GetCustomersAsync());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerAsync([FromRoute] int id)
        {
            var customer = new CustomerService().GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound("No record found matching the given id");
            }
            else
            {
                return Ok(customer);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer info is null");
            }
            else
            {
                await new CustomerService().AddCustomerAsync(customer);
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int id, [FromBody] Customer customer)
        {
            if (new CustomerService().GetCustomerAsync(id) == null)
            {
                return NotFound("No record found matching the given id");
            }
            else
            {
                await new CustomerService().UpdateCustomerAsync(id, customer);
                return Ok("Record updated succesfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int id)
        {
            if (new CustomerService().GetCustomerAsync(id) == null)
            {
                return NotFound("There is no such customer");
            }
            else
            {
                await new CustomerService().DeleteCustomerAsync(id);
                return Ok("Customer deleted");
            }
        }
    }
}
