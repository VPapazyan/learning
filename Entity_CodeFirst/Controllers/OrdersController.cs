using Entity_CodeFirst.DAL;
using Entity_CodeFirst.Entities;
using Entity_CodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Entity_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<OrderModel>> GetCustomersAsync()
        {
            var orders = await _unitOfWork.Orders.GetOrdersAsync();

            if (orders == null)
            {
                return NotFound("No record found");
            }
            else
            {
                return Ok(orders);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrderAsync([FromRoute] int id)
        {
            var order = await _unitOfWork.Orders.GetOrderAsync(id);

            if (order == null)
            {
                return NotFound("No record found matching the given id");
            }
            else
            {
                return Ok(order);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order info is null");
            }
            else
            {
                await _unitOfWork.Orders.AddOrderAsync(order);
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync([FromRoute] int id, [FromBody] Order order)
        {
            if (_unitOfWork.Orders.GetOrderAsync(id) == null)
            {
                return NotFound("No record found matching the given id");
            }
            else
            {
                await _unitOfWork.Orders.UpdateOrderAsync(id, order);
                return Ok("Record updated succesfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int id)
        {
            if (_unitOfWork.Orders.GetOrderAsync(id) == null)
            {
                return NotFound("There is no such customer");
            }
            else
            {
                await _unitOfWork.Orders.DeleteOrderAsync(id);
                return Ok("Order deleted");
            }
        }
    }
}
