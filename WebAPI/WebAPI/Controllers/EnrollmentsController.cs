using BsLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]Async")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly EnrollmentsService _enrollmentsService;

        public EnrollmentsController(EnrollmentsService enrollmentsService)
        {
            _enrollmentsService = enrollmentsService;
        }

        // GET: api/EnrollmentsAsync/GetEnrollmentByIdAsync/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetEnrollmentByIdAsync(int id)
        {
            var enrollment = await _enrollmentsService.GetEnrollmentByIDAsync(id);
            if (enrollment == null)
                return NotFound($"Enrollment with ID {id} not found");

            return Ok(enrollment);
        }

        // GET: api/EnrollmentsAsync/GetAllEnrollmentsAsync
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEnrollmentsAsync()
        {
            var enrollments = await _enrollmentsService.GetAllStudentsAsync();
            return Ok(enrollments);
        }

        // PUT: api/EnrollmentsAsync/ActivateEnrollAsync/5
        [HttpPut("[action]/{id:int}")]
        public async Task<IActionResult> ActivateEnrollAsync(int id)
        {
            var activated = await _enrollmentsService.ActivateEnrollAsync(id);
            if (!activated)
                return NotFound($"Enrollment with ID {id} not found or already active");

            return Ok("Enrollment activated successfully");
        }

        // PUT: api/EnrollmentsAsync/UnActivateEnrollAsync/5
        [HttpPut("[action]/{id:int}")]
        public async Task<IActionResult> UnActivateEnrollAsync(int id)
        {
            var unActivated = await _enrollmentsService.UnActivateEnrollAsync(id);
            if (!unActivated)
                return NotFound($"Enrollment with ID {id} not found or already inactive");

            return Ok("Enrollment deactivated successfully");
        }
    }
}
