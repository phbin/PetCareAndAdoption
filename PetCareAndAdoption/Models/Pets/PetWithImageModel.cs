using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models.Posts;

namespace PetCareAndAdoption.Models.Pets
{
    public class PetWithImageModel
    {
        public PetModel PetModel { get; set; }
        public List<ImagePetModel> Images { get; set; }
        public List<HistoryVaccineModel> History { get; set; }
        public List<NextVaccineModel> Next { get; set; }

    }
}
