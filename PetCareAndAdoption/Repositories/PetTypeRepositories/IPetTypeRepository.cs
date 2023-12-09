using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Pets;

namespace PetCareAndAdoption.Repositories.PetTypeRepositories
{
    public interface IPetTypeRepository
    {
        public Task<List<PetSpeciesModel>> GetAllSpeciesAsync();
        public Task<List<PetBreedsModel>> GetAllBreedsAsync();
        public Task<PetBreedsModel> GetBreedBySpeciesIdAsync(string speciesID);
    }
}
