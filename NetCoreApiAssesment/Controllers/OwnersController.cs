using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiAssesment.Data.Repositories;
using NetCoreApiAssesment.Model;

namespace NetCoreApiAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnersRepository _ownerRepository;

        public OwnersController(IOwnersRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            return Ok(await _ownerRepository.GetAllOwners());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody]Owners owner)
        {
            if(owner == null)
                return BadRequest();
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var created = await _ownerRepository.InsertOwner(owner);

            return Created("created" ,created);
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOwner([FromBody] Owners owner)
        {
            if (owner == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           await _ownerRepository.UpdateOwner(owner);

            return NoContent();

        }
    }
}
