using PetCareAndAdoption.Models.Pets;

namespace PetCareAndAdoption.Repositories.MyPetRepositories
{
    public interface IPetRepository
    {
        public Task<string> AddPetAsync(PetModel model, List<ImagePetModel> img, List<HistoryVaccineModel> his, List<NextVaccineModel> next );
        //public Task UpdatePetAsync(string petID, PetInfoModel model);
        public Task<string> DeletePetAsync(string petID);
        public Task<List<GetAllPetModel>> GetAllPetAsync();
    }
}
