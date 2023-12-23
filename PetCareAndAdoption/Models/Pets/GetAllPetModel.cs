using PetCareAndAdoption.Models.Posts;

namespace PetCareAndAdoption.Models.Pets
{
    public class GetAllPetModel
    {
        public PetInfoModel PetInfoModel { get; set; }
        public string[] Images { get; set; }
        public HistoryVaccineModel[] History { get; set; }
        public HistoryVaccineModel[] Next{ get; set; }

    }
}
