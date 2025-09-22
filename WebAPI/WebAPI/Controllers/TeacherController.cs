using BsLayer.Services;
using Dtos.TeacherDtos;
using Dtos.TeacherDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // 1. Get All Teachers
        [HttpGet(Name = "GetAllTeachersAsync")]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        // 2. Get Teacher By ID
        [HttpGet("{id}", Name = "GetTeacherByIdAsync")]
        public async Task<IActionResult> GetTeacherByIdAsync(short id)
        {
            var teacher = await _teacherService.GetTeacherByIDAsync(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        // 3. Add New Teacher
        [HttpPost(Name = "AddNewTeacherAsync")]
        public async Task<IActionResult> AddNewTeacherAsync([FromBody] addTeacherDtos dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var teacherId = await _teacherService.AddNewAsync(dto);
            return Ok($"Teacher ID : {teacherId}");
        }

        // 4. Update Teacher
        [HttpPut(Name = "UpdateTeacherAsync")]
        public async Task<IActionResult> UpdateTeacherAsync([FromBody] updateTeacherDtos dto)
        {
           
            var result = await _teacherService.UpdateTeacherAsync(dto);
            if (!result) return NotFound();
            return NoContent();
        }

        // 5. Delete Teacher
        [HttpDelete("{id}", Name = "DeleteTeacherAsync")]
        public async Task<IActionResult> DeleteTeacherAsync(short id)
        {
            var result = await _teacherService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // 6. Update Teacher + Person
        [HttpPut("with-person", Name = "UpdateTeacherWithPersonAsync")]
        public async Task<IActionResult> UpdateTeacherWithPersonAsync([FromBody] updateTeachrerPersonDtos dto)
        {
            
            var result = await _teacherService.UpdateTeacherPeopleAsync(dto);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
