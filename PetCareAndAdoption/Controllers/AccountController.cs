using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCareAndAdoption.Models.Authentication;
using PetCareAndAdoption.Repositories.AuthenticationRepositories;

namespace PetCareAndAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;
        public AccountController(IAccountRepository repo)
        {
            accountRepo = repo;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await accountRepo.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok("SignUp successful");
            }
            else
            {
                return BadRequest("SignUp failed");
            }
        }
        [HttpPost("VerifyPhoneNumber")]
        public async Task<IActionResult> VerifyPhoneNumber(ConfirmSignUpModel model)
        {
            var result = await accountRepo.ConfirmSignUpAsync(model.OTP, model.SignUpModel);
            if (result.Succeeded)
            {
                return Ok("SignUp confirmed");
            }
            else
            {
                return BadRequest("SignUp confirmation failed");
            }
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            var result = await accountRepo.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpPost("ForgetPasswordCheckExist")]
        public async Task<IActionResult> ForgetPassword(string phoneNumber)
        {
            var result = await accountRepo.CheckPhoneNumberAsync(phoneNumber);

            // Kiểm tra xem hàm CheckPhoneNumberAsync có thành công hay không
            if (result.Succeeded)
            {
                return Ok(new { Message = "OTP sent successfully." });
            }
            else
            {
                // Trả về lỗi với mô tả từ IdentityResult
                return BadRequest(new { Error = result.Errors.FirstOrDefault()?.Description });
            }
        }
        [HttpPost("CheckOTPResetPassword")]
        public async Task<IActionResult> CheckOTPResetPassword(string phoneNumber, string otp )
        {
            var result = await accountRepo.ConfirmOTPAsync(phoneNumber,otp);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Password changed successfully." });
            }
            else
            {
                // Trả về lỗi với mô tả từ IdentityResult
                return BadRequest(new { Error = result.Errors.FirstOrDefault()?.Description });
            }
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string phoneNumber, string newPassword)
        {
            var result = await accountRepo.ResetPasswordAsync(phoneNumber, newPassword);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Password changed successfully." });
            }
            else
            {
                // Trả về lỗi với mô tả từ IdentityResult
                return BadRequest(new { Error = result.Errors.FirstOrDefault()?.Description });
            }
        }
    }
}
