using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiAssesment.Data.Repositories;
using NetCoreApiAssesment.Model;

namespace NetCoreApiAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesRepository _vehiclesRepository;

        public VehiclesController(IVehiclesRepository vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            return Ok(await _vehiclesRepository.GetAllVehicles());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllVehiclesOwner(int id)
        {
            return Ok(await _vehiclesRepository.GetAllVehiclesOwner(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] Vehicles vehicle)
        {
            if (vehicle == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _vehiclesRepository.InsertVehicle(vehicle);

            return Created("created", created);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] Vehicles vehicle)
        {
            if (vehicle == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _vehiclesRepository.UpdateVehicle(vehicle);

            return NoContent();

        }
    }
}
