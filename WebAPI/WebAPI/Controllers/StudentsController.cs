using BsLayer.Services;
using Dtos.EnrollStudentsDtos.StudentsDtos;
using Dtos.EnrollStudentsDtos.EnrollmentDetials;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]Async")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService _studentsService;

        public StudentsController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        // GET: api/StudentsAsync/GetStudentByIdAsync/5
        [HttpGet("[action]/{id:int}") ]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var student = await _studentsService.GetStudentByIDAsync(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found");

            return Ok(student);
        }

        // GET: api/StudentsAsync/GetAllStudentsAsync
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _studentsService.GetAllStudentsAsync();
            return Ok(students);
        }

        // POST: api/StudentsAsync/AddStudentAsync
        [HttpPost("[action]")]
        public async Task<IActionResult> AddStudentAsync([FromBody] addStudentsEnrollmentDetialsFTDtos dto)
        {
            
            var studentId = await _studentsService.addStudentsAsync(dto);

            if (studentId == 0)
                return BadRequest();

            return Ok($"added new Studnet ID :  [{studentId}] successfully");
        }

        // PUT: api/StudentsAsync/UpdateStudentAsync
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateStudentAsync([FromBody] updateStudentsPersonDtos dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _studentsService.UpdateStudentPersonAsync(dto);

            if (!updated)
                return NotFound("Student not found or update failed");

            return Ok("Student updated successfully");
        }

        // DELETE: api/StudentsAsync/DeleteStudentAsync/5
        //[HttpDelete("[action]/{id:int}")]
        //public async Task<IActionResult> DeleteStudentAsync(int id)
        //{
        //    var deleted = await _studentsService.DeleteStudnetAsync(id);

        //    if (!deleted)
        //        return NotFound($"Student with ID {id} not found or already deleted");

        //    return Ok("Student deleted successfully");
        //}
    }
}
