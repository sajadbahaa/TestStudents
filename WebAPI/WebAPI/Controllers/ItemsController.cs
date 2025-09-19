using BsLayer;
using BsLayer.Services;
using Dtos.ItemWithSpeclizeDtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemService;
        //private readonly IValidator<addUpdateSpecilizesDto> _validator;

        public ItemsController(
            ItemsService itemService)
            //IValidator<addUpdateSpecilizesDto> validator)
        {
            _itemService = itemService;
            //_validator = validator;
        }

        // GET: api/Specilze
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _itemService.GetAllAsync();
            return data == null ? NotFound() : Ok(data);
        }

        // GET: api/Specilze/5
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByIdAsync(short id)
        {

            var item = await _itemService.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/Specilze
        [HttpPost("AddItemsToSpecilzeFTAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] addItemsToSpecilzeFirstTimeDtos dto)
        {
            // Validation

            var res = await _itemService.AddSpecilzeForItemsFirstTimeAsync(dto);
            return !res ? BadRequest() : Ok(new{ Message = "تم الإضافة بنجاح" });
        }

        [HttpPost("AddItemsToSpecilzeAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] addItemsToSpeiclzeDtos dto)
        {
            // Validation

            var res = await _itemService.AddSpecilzeForItemsAsync(dto);
            return !res ? BadRequest() : Ok(new { Message = "تم الإضافة بنجاح" });
        }


        // PUT: api/Specilze
        [HttpPut("UpdateItemsAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateItemsDto dto)
        {
            // Validation
        
            var success = await _itemService.UpdateItemsAsync(dto);
            if (!success)
                return NotFound(new { Message = "لم يتم العثور على العنصر للتحديث" });

            return Ok(new { Message = "تم التحديث بنجاح" });
        }

        [HttpPut("UpdateItemsWithSpecilzeAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateItemsWithSpecilzeDtos dto)
        {
            // Validation

            var success = await _itemService.UpdateItemsWithSpecilizeAsync(dto);
            if (!success)
                return NotFound(new { Message = "لم يتم العثور على العنصر للتحديث" });

            return Ok(new { Message = "تم التحديث بنجاح" });
        }


        // DELETE: api/Specilze/5
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            var success = await _itemService.DeleteAsync(id);
            if (!success)
                return NotFound(new { Message = "لم يتم العثور على العنصر للحذف" });

            return Ok(new { Message = "تم الحذف بنجاح" });
        }
    }
}
