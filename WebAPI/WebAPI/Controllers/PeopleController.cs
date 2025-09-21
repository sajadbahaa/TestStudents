using BsLayer.Services;
using Dtos.PeopleDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        // GET: api/People
        [HttpGet("GetAllPeopleAsync")]
        public async Task<ActionResult<List<findPeopleDtos>>> GetAllPeopleAsync()
        {
            var people = await _peopleService.GetAllPeopleAsync();
            if (people == null || people.Count == 0)
                return NotFound("لا يوجد أشخاص.");
            return Ok(people);
        }

        // GET: api/People/5
        [HttpGet("GetPersonByIdAsync/{id}")]
        public async Task<ActionResult<findPeopleDtos>> GetPersonByIdAsync(int id)
        {
            var person = await _peopleService.GetByIDAsync(id);
            if (person == null)
                return NotFound("الشخص غير موجود.");
            return Ok(person);
        }

        // POST: api/People
        [HttpPost("AddPersonAsync")]
        public async Task<ActionResult<int>> AddPersonAsync([FromBody] addPeopleDtos dto)
        {
            int id = await _peopleService.AddAsync(dto);
            return id==0?BadRequest():Ok($"Person ID : {id}");
        }

        // PUT: api/People/5
        [HttpPut("UpdatePersonAsync")]
        public async Task<ActionResult> UpdatePersonAsync([FromBody] updatePeopleDtos dto)
        {
            bool result = await _peopleService.UpdateAsync(dto);
            if (!result)
                return NotFound("الشخص غير موجود للتحديث.");
            return NoContent();
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonAsync(int id)
        {
            var result = await _peopleService.DeleteAsync(id);
            if (!result)
                return NotFound("الشخص غير موجود للحذف.");
            return NoContent();
        }
    }
}
