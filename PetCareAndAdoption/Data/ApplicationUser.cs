using Microsoft.AspNetCore.Identity;

namespace PetCareAndAdoption.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; } = null!;
    }
}
