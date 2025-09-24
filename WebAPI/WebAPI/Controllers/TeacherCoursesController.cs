using BsLayer.Services;
using Dtos.TeacherCoursesDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCoursesController : ControllerBase
    {
        private readonly TeacherCoursesService _teacherCoursesService;

        public TeacherCoursesController(TeacherCoursesService teacherCoursesService)
        {
            _teacherCoursesService = teacherCoursesService;
        }

        // POST: api/TeacherCourses
        [HttpPost("GetAllTeachersCoursesAsync")]
        public async Task<IActionResult> AddTeacherCoursesAsync([FromBody] addTeacherCourseDtos dto)
        {
            var result = await _teacherCoursesService.AddSingleTeacherWithCoursesAsync(dto);

            return result? Ok("Courses assigned successfully."):BadRequest();
        }

        // PUT: api/TeacherCourses/{id}
        [HttpPut("UpdateTeacherCourseAsyncBy")]
        public async Task<IActionResult> UpdateTeacherCourseAsync([FromBody] updateTeacherCoursrDtos dto)
        {

            var result = await _teacherCoursesService.UpdateAsync(dto);

            if (!result)
                return NotFound($"TeacherCourse with ID {dto.TeacherCourseID} not found.");

            return Ok("TeacherCourse updated successfully.");
        }

        // DELETE: api/TeacherCourses/{id}
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteTeacherCourseAsync(int id)
        {
            var result = await _teacherCoursesService.DeleteAsync(id);

            if (!result)
                return NotFound($"TeacherCourse with ID {id} not found.");

            return Ok("TeacherCourse deleted successfully.");
        }

        // GET: api/TeacherCourses/{id}
        [HttpGet("GetTeacherCourseAsyncBy/{id}")]
        public async Task<ActionResult<findTeacherCourseDtos>> GetTeacherCourseByIdAsync(int id)
        {
            var result = await _teacherCoursesService.GetTeacherCoursByIDAsync(id);

            if (result == null)
                return NotFound($"TeacherCourse with ID {id} not found.");

            return Ok(result);
        }

        // GET: api/TeacherCourses
        [HttpGet("GetAllTeacherCoursesAsync")]
        public async Task<ActionResult<List<findTeacherCourseDtos>>> GetAllTeacherCoursesAsync()
        {
            var result = await _teacherCoursesService.GetTeacherCoursByIDAsync();

            if (result == null || result.Count == 0)
                return NotFound("No teacher courses found.");

            return Ok(result);
        }
    }
}
