using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models.Pets;
using System.Drawing;

namespace PetCareAndAdoption.Repositories.MyPetRepositories
{
    public class PetRepository : IPetRepository
    {
        private readonly IConfiguration configuration;
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public PetRepository(MyDbContext context, IMapper mapper,
            IConfiguration configuration, IMemoryCache memoryCache)
        {
            this.configuration = configuration;
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddPetAsync(PetModel model, List<ImagePetModel> img, List<HistoryVaccineModel> his, List<NextVaccineModel> next)
        {
            if (model != null)
            {
                var newPet = new PetInfoModel
                {
                    petID = Guid.NewGuid().ToString(),
                    petName = model.petName,
                    sex = model.sex,
                    species = model.species,
                    breed = model.breed,
                    age = model.age,
                    weight = model.weight,
                    description = model.description,
                    userID = model.userID,
                };

                var petImages = new List<ImageModel>();
                var history = new List<HistoryVaccineTableModel>();
                var nextVaccine = new List<NextVaccineTableModel>();

                foreach (var i in img)
                {
                    var newImage = new PetCareAndAdoption.Models.Pets.ImageModel
                    {
                        imgPetID = Guid.NewGuid().ToString(),
                        petID = newPet.petID,
                        image = i.image,
                    };
                    petImages.Add(newImage);

                }
                var pet = _mapper.Map<MyPets>(newPet);
                _context.MyPets!.Add(pet);
                await _context.SaveChangesAsync();

                foreach (var image in petImages)
                {
                    var imgPet = _mapper.Map<PetImages>(image);
                    _context.PetImages!.Add(imgPet);

                    await _context.SaveChangesAsync();
                }
                //vaccine history
                foreach (var i in his)
                {
                    var newHis = new HistoryVaccineTableModel
                    {
                        historyVaccineID = Guid.NewGuid().ToString(),
                        petID = newPet.petID,
                        date = i.date,
                        note = i.note,
                    };
                    history.Add(newHis);

                }
              

                foreach (var i in history)
                {
                    var hisPet = _mapper.Map<HistoryVaccine>(i);
                    _context.HistoryVaccine!.Add(hisPet);

                    await _context.SaveChangesAsync();
                }
                //next
                foreach (var i in next)
                {
                    var newNext = new NextVaccineTableModel
                    {
                        nextVaccineID = Guid.NewGuid().ToString(),
                        petID = newPet.petID,
                        date = i.date,
                        note = i.note,
                    };
                    nextVaccine.Add(newNext);

                }

                foreach (var i in nextVaccine)
                {
                    var nextPet = _mapper.Map<NextVaccine>(i);
                    _context.NextVaccine!.Add(nextPet);

                    await _context.SaveChangesAsync();
                }


                return pet.petID;
            }
            else
            {
                return "Invalid ";
            }
        }

        public async Task<string> DeletePetAsync(string petID)
        {
            var delPet = _context.MyPets!.SingleOrDefault(b => b.petID == petID);
            if (delPet != null)
            {
                _context.MyPets!.Remove(delPet);
                await _context.SaveChangesAsync();
                return "Success";
            }
            return "Remove pet failed!";
        }

        public async Task<List<GetAllPetModel>> GetAllPetAsync()
        {
            var pets = await _context.MyPets!
                                        .ToListAsync();
            var result = new List<GetAllPetModel>();
            foreach (var pet in pets)
            {
                var imageEntities = await _context.PetImages!
                    .Where(img => img.petID == pet.petID)
                    .ToListAsync();
                var imageUrls = imageEntities.Select(img => img.image).ToArray();

                var hisVacEntities = await _context.HistoryVaccine!
                     .Where(vac => vac.petID == pet.petID)
                     .ToListAsync();
                var historyVaccine = hisVacEntities
                    .Select(vac => new HistoryVaccineModel { date = vac.date, note = vac.note })
                    .ToArray();

                var nextVacEntities = await _context.NextVaccine!
                    .Where(vac => vac.petID == pet.petID)
                    .ToListAsync();
                var nextVaccine = nextVacEntities
                    .Select(vac => new HistoryVaccineModel { date = vac.date, note = vac.note })
                    .ToArray();

                var postModel = _mapper.Map<PetInfoModel>(pet);

                result.Add(new GetAllPetModel
                {
                    PetInfoModel = postModel,
                    Images = imageUrls,
                    History = historyVaccine,
                    Next = nextVaccine
                });
            }
            return result;
        }

        //public async Task UpdatePetAsync(string petID, PetInfoModel model)
        //{
        //    if (petID == model.petID)
        //    {
        //        var updatePet = _mapper.Map<MyPets>(model);
        //        _context.MyPets!.Update(updatePet);
        //        await _context.SaveChangesAsync();

        //    }
        //}
    }
}
