using Microsoft.AspNetCore.Identity;
using PetCareAndAdoption.Models.Authentication;

namespace PetCareAndAdoption.Repositories.AuthenticationRepositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model); 
        public Task<string> SignInAsync(SignInModel model);
    }
}
