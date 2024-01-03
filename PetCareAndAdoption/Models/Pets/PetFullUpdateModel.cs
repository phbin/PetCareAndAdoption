namespace PetCareAndAdoption.Models.Pets
{
    public class PetFullUpdateModel
    {
        public PetUpdateModel PetModel { get; set; }
        public List<ImagePetModel> Images { get; set; }
        public List<HistoryVaccineModel> History { get; set; }
        public List<NextVaccineModel> Next { get; set; }
    }
}
