using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Pets;

namespace PetCareAndAdoption.Repositories.PetTypeRepositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;

        public PetTypeRepository(MyDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PetBreedsModel>> GetAllBreedsAsync()
        {
            var breeds = await _context.Breeds!.ToListAsync();
            return _mapper.Map<List<PetBreedsModel>>(breeds);
        }

        public async Task<List<PetSpeciesModel>> GetAllSpeciesAsync()
        {
            var species = await _context.Species
                   .OrderBy(s => s.speciesName )
                   .ToListAsync(); 
            return _mapper.Map<List<PetSpeciesModel>>(species);
        }

        public async Task<List<PetBreedsModel>> GetBreedBySpeciesIdAsync(string speciesID)
        {
            var breeds = await _context.Breeds
                    .Where(b => b.Species.speciesID == speciesID)
                    .ToListAsync();
            return _mapper.Map<List<PetBreedsModel>>(breeds);
        }
    }
}
