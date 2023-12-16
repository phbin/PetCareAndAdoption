using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCareAndAdoption.Repositories;
using PetCareAndAdoption.Repositories.PetTypeRepositories;

namespace PetCareAndAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private IPetTypeRepository _petRepo;

        public PetTypeController(IPetTypeRepository repo)
        {
            _petRepo = repo;
        }

        [HttpGet("Species")]
        public async Task<IActionResult> GetAllSpecíes()
        {
            try
            {
                return Ok(await _petRepo.GetAllSpeciesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("Breeds")]
        public async Task<IActionResult> GetAllBreeds()
        {
            try
            {
                return Ok(await _petRepo.GetAllBreedsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{speciesID}")]
        public async Task<IActionResult> GetBreedBySpeciesId(string speciesID)
        {
            var user = await _petRepo.GetBreedBySpeciesIdAsync(speciesID);
            return user == null ? NotFound() : Ok(user);
        }

    }
}
