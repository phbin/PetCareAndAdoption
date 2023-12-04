using Microsoft.AspNetCore.Identity;
using PetCareAndAdoption.Models.Authentication;

namespace PetCareAndAdoption.Repositories.AuthenticationRepositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<IdentityResult> ConfirmSignUpAsync(string enteredOTP, SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
        public Task<IdentityResult> CheckPhoneNumberAsync(string phoneNumber);
        public Task<IdentityResult> ConfirmOTPAsync(string phoneNumber, string enteredOtp);
        public Task<IdentityResult> ResetPasswordAsync(string phoneNumber, string newPassword);

    }
}
