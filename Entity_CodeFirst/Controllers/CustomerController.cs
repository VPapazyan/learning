using Entity_CodeFirst.DAL;
using Entity_CodeFirst.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Entity_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomersAsync()
        {
            var customers = await _unitOfWork.Customers.GetCustomersAsync();

            if (customers == null)
            {
                return NotFound("No record found");
            }
            else
            {
                return Ok(customers);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerAsync([FromRoute] int id)
        {
            var customer = await _unitOfWork.Customers.GetCustomerAsync(id);

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
                await _unitOfWork.Customers.AddCustomerAsync(customer);
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int id, [FromBody] Customer customer)
        {
            if (_unitOfWork.Customers.GetCustomerAsync(id) == null)
            {
                return NotFound("No record found matching the given id");
            }
            else
            {
                await _unitOfWork.Customers.UpdateCustomerAsync(id, customer);
                return Ok("Record updated succesfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int id)
        {
            if (_unitOfWork.Customers.GetCustomerAsync(id) == null)
            {
                return NotFound("There is no such customer");
            }
            else
            {
                await _unitOfWork.Customers.DeleteCustomerAsync(id);
                return Ok("Customer deleted");
            }
        }
    }
}
