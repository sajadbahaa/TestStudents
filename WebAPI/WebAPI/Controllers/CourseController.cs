using BsLayer;
using BsLayer.Services;
using Dtos.CoursesDtos;
using Dtos.ItemWithSpeclizeDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepLayer;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        readonly CourseService _courseService;
        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _courseService.GetAllCoursesAsync();
            return data == null ? NotFound() : Ok(data);
        }

        // GET: api/Specilze/5
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByIdAsync(short id)
        {

            var item = await _courseService.GetCourseByIDAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/Specilze
        [HttpPost("AddAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] addCourseDto dto)
        {

            var id = await _courseService.AddCourseAsync(dto);
            return id == 0 ? BadRequest() : Ok(new { Id = id, Message = "تم الإضافة بنجاح" });
        }

        // PUT: api/Specilze
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] updateCourseDtos dto)
        {
            // Validation

            var success = await _courseService.UpdateCourseAsync(dto);
            if (!success)
                return NotFound(new { Message = "لم يتم العثور على العنصر للتحديث" });

            return Ok(new { Message = "تم التحديث بنجاح" });
        }

        // DELETE: api/Specilze/5
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(short id)
        {
            var success = await _courseService.DeleteCourseAsync(id);
            if (!success)
                return NotFound(new { Message = "لم يتم العثور على العنصر للحذف" });

            return Ok(new { Message = "تم الحذف بنجاح" });
        }


        [HttpPut("ActivateAsync/{id}")]
        public async Task<IActionResult> ActivateAsync(short id)
        {
            var success = await _courseService.ActivatedCourseAsync(id);
            if (!success)
                return NotFound(new { Message = "لم يتم العثور على العنصر للتفعيل" });

            return Ok(new { Message = "تم التفعيل بنجاح" });
        }

    }
}
