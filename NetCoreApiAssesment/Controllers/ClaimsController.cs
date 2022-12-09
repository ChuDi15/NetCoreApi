using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiAssesment.Data.Repositories;
using NetCoreApiAssesment.Model;

namespace NetCoreApiAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsRepository _claimsRepository;

        public ClaimsController(IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClaims()
        {
            return Ok(await _claimsRepository.GetAllClaims());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllClaimsVehicle(int id)
        {
            return Ok(await _claimsRepository.GetAllClaimsVehicle(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClaim([FromBody] Claims claim)
        {
            if (claim == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _claimsRepository.InsertClaim(claim);

            return Created("created", created);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateClaim([FromBody] Claims claim)
        {
            if (claim == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _claimsRepository.UpdateClaim(claim);

            return NoContent();

        }
    }
}
