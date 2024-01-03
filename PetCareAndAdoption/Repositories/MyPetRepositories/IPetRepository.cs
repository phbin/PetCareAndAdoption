using PetCareAndAdoption.Models.Pets;

namespace PetCareAndAdoption.Repositories.MyPetRepositories
{
    public interface IPetRepository
    {
        public Task<string> AddPetAsync(PetModel model, List<ImagePetModel> img, List<HistoryVaccineModel> his, List<NextVaccineModel> next );
        public Task<string> UpdatePetAsync(string petID, PetUpdateModel model, List<ImagePetModel> img, List<HistoryVaccineModel> his, List<NextVaccineModel> next);
        public Task<string> DeletePetAsync(string userID, string petID);
        public Task<List<GetAllPetModel>> GetAllPetAsync();
    }
}
