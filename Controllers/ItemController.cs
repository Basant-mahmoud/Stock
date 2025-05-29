using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Stock.Application.Dto;
using Stock.Stock.Application.Helper;
using Stock.Stock.Application.InterfacesServices;
using Stock.Stock.Application.ServicesClass;
using Stock.Stock.Domain.Models;

namespace Stock.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ItemDto item)
        {
            try
            {
                var userId = User.GetUserId();
                if (userId == null)
                {
                    return Unauthorized("User ID not found in the token");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _itemService.addAsync(item);
                return Ok(new { Message = "item created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateItemDto item)
        {
            try
            {
                var userId = User.GetUserId();
                if (userId == null)
                {
                    return Unauthorized("User ID not found in the token");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _itemService.UpdateAsync(item);
                return Ok(new { Message = "item updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized("User ID not found in the token");
            }
            await _itemService.deleteAsync(id);
            return Ok(new { Message = "item deleted successfully" });
        }
        [HttpGet("GetAllitem")]
        public async Task<IActionResult> GetAllItem()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized("User ID not found in the token");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userId = User.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token");
            }

            var item = await _itemService.GetAsync(id);
            if (item == null)
            {
                return NotFound($"Item with ID {id} not found.");
            }

            return Ok(item);
        }
        [HttpPost("IncreaseQuantity")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> IncreaseQuantity([FromBody] QuantityDto item)
        {
            try
            {
                var userId = User.GetUserId();
                if (userId == null)
                {
                    return Unauthorized("User ID not found in the token");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _itemService.IncreaseStockAsync(item.id,item.quantity);
                return Ok(new { Message = "item updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("DecreaseQuantity")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DecreaseQuantity([FromBody] QuantityDto item)
        {
            try
            {
                var userId = User.GetUserId();
                if (userId == null)
                {
                    return Unauthorized("User ID not found in the token");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _itemService.DecreaseStockAsync(item.id, item.quantity);
                return Ok(new { Message = "item updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
