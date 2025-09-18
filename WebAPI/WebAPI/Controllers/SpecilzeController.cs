using AutoMapper;
using BsLayer;
using Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecilzeController : ControllerBase
    {
        private readonly SpecilizationsService _specilizationsService;
        private readonly IValidator<addUpdateSpecilizesDto> _validator;

        public SpecilzeController(
            SpecilizationsService specilizationsService,
            IValidator<addUpdateSpecilizesDto> validator)
        {
            _specilizationsService = specilizationsService;
            _validator = validator;
        }

        // GET: api/Specilze
        [HttpGet ("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _specilizationsService.GetAllAsync();
            return data==null?NotFound(): Ok(data);
        }

        // GET: api/Specilze/5
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult>GetByIdAsync(short id)
        {
            
            var item = await _specilizationsService.GetByIdAsync(id);
             
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/Specilze
        [HttpPost("AddAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] addUpdateSpecilizesDto dto)
        {
            // Validation
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var id = await _specilizationsService.AddAsync(dto);
            return id==0?BadRequest():Ok(new { Id = id, Message = "تم الإضافة بنجاح" });
        }

        // PUT: api/Specilze
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] addUpdateSpecilizesDto dto)
        {
            // Validation
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var success = await _specilizationsService.UpdateAsync(dto);
            if (!success)
                return NotFound(new { Message = "لم يتم العثور على العنصر للتحديث" });

            return Ok(new { Message = "تم التحديث بنجاح" });
        }

        // DELETE: api/Specilze/5
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            var success = await _specilizationsService.DeleteAsync(id);
            if (!success)
                return NotFound(new { Message = "لم يتم العثور على العنصر للحذف" });

            return Ok(new { Message = "تم الحذف بنجاح" });
        }
    }
}
