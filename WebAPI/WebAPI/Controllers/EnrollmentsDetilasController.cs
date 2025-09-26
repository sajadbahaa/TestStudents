using BsLayer.Services;
using Dtos.EnrollStudentsDtos.Enrollment;
using Dtos.EnrollStudentsDtos.EnrollmentDetials;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]Async")]
    [ApiController]
    public class EnrollmentsDetilasController : ControllerBase
    {
        private readonly EnrollmentsDetilasService _enrollmentsDetilasService;

        public EnrollmentsDetilasController(EnrollmentsDetilasService enrollmentsDetilasService)
        {
            _enrollmentsDetilasService = enrollmentsDetilasService;
        }

        // GET: api/EnrollmentsDetilasAsync/GetEnrollmentDetilasByIDAsync/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetEnrollmentDetilasByIDAsync(int id)
        {
            var detilas = await _enrollmentsDetilasService.GetEnrollmentDetilasByIDAsync(id);
            if (detilas == null)
                return NotFound($"Enrollment detilas with ID {id} not found");

            return Ok(detilas);
        }

        // GET: api/EnrollmentsDetilasAsync/GetAllEnrollmentDetilasAsync
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEnrollmentDetilasAsync()
        {
            var detilas = await _enrollmentsDetilasService.GetAllEnrollmentDetilasAsync();
            return Ok(detilas);
        }

        // POST: api/EnrollmentsDetilasAsync/AddEnrollDetilasAsync
        [HttpPost("[action]")]
        public async Task<IActionResult> AddEnrollDetilasAsync([FromBody] addStudentsEnrollmentDetialsDtos dto)
        {
            
            var added = await _enrollmentsDetilasService.AddEnrollDetilasAsync(dto);
            if (!added)
                return BadRequest("Cannot add enrollment detilas. Enrollment might be active or invalid.");

            return Ok("Enrollment detilas added successfully");
        }

        // DELETE: api/EnrollmentsDetilasAsync/DeleteAsync/5
        [HttpDelete("[action]/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _enrollmentsDetilasService.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Enrollment detilas with ID {id} not found or already deleted");

            return Ok("Enrollment detilas deleted successfully");
        }
    }
}
