using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Authentication;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Twilio.Http;

namespace PetCareAndAdoption.Repositories.AuthenticationRepositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public AccountRepository(MyDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, IMemoryCache memoryCache)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            _context = context;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<IdentityResult> CheckPhoneNumberAsync(string phoneNumber)
        {
            var user = await userManager.FindByNameAsync(phoneNumber);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }
            else
            {
                // Thực hiện gửi OTP
                var otp = GenerateRandomOTP();
                SendOTPToPhoneNumber(phoneNumber, otp);

                _memoryCache.Set($"ChangePasswordOTP_{phoneNumber}", otp, TimeSpan.FromMinutes(5));
                return IdentityResult.Success;
            }
        }

        public async Task<IdentityResult> ConfirmOTPAsync(string phoneNumber, string enteredOtp)
        {
            var savedOtp = _memoryCache.Get<string>($"ChangePasswordOTP_{phoneNumber}");

            if (enteredOtp == savedOtp)
            {
                // Kiểm tra mật khẩu và xác nhận mật khẩu

                _memoryCache.Remove($"ChangePasswordOTP_{phoneNumber}");

                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError { Description = "Invalid OTP." });
        }

        public async Task<IdentityResult> ResetPasswordAsync(string phoneNumber, string newPassword)
        {
            var user = await userManager.FindByNameAsync(phoneNumber);
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, newPassword);
            var updateUser = await _context.Users.FirstOrDefaultAsync(u => u.userID == phoneNumber);

            if (updateUser != null)
            {
                updateUser.password = newPassword;

                await _context.SaveChangesAsync();
            }

            if (result.Succeeded)
            {
                return IdentityResult.Success;
            }
            else
            {
                return result;
            }
        }


        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.PhoneNumber, model.Password, false, false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.MobilePhone, model.PhoneNumber),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey,
                SecurityAlgorithms.HmacSha512Signature)
                );
            var user = await _context.Users.FirstOrDefaultAsync(u => u.userID == model.PhoneNumber);

            if (user == null)
            {
                return string.Empty; 
            }
            var userResponse = new
            {
                user = new
                {
                    phoneNumber = user.userID,
                    district = user.district,
                    province=user.province,
                    avatar = user.avatar,
                    name = user.name,
                },
                token = new JwtSecurityTokenHandler().WriteToken(token),

            };
            var jsonResponse = JsonConvert.SerializeObject(userResponse);

            return jsonResponse;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var existingUser = await userManager.FindByNameAsync(model.PhoneNumber);

            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User already exists." });
            }
            var user = new ApplicationUser
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                UserName = model.PhoneNumber,
            };

            var otp = GenerateRandomOTP();
            SendOTPToPhoneNumber(model.PhoneNumber, otp);
            _memoryCache.Set($"SignUpOTP_{model.PhoneNumber}", otp, TimeSpan.FromMinutes(5));


            return IdentityResult.Success;
        }

        public async Task<IdentityResult> ConfirmSignUpAsync(string enteredOTP, SignUpModel model)
        {
            // Lấy mã OTP đã lưu trước đó
            var savedOTP = _memoryCache.Get<string>($"SignUpOTP_{model.PhoneNumber}");

            if (enteredOTP == savedOTP)
            {
                // Mã OTP đúng, tiếp tục với quá trình đăng ký
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.PhoneNumber,
                };

                var newUser = _mapper.Map<UserInfo>(model);
                _context.Users!.Add(newUser);
                await _context.SaveChangesAsync();

                var result = await userManager.CreateAsync(user, model.Password);

                _memoryCache.Remove($"SignUpOTP_{model.PhoneNumber}");

                return result;
            }
            else
            {
                // Mã OTP không khớp
                return IdentityResult.Failed(new IdentityError { Description = "Invalid SignUp OTP" });
            }
        }

        private string GenerateRandomOTP()
        {
            // Sinh mã OTP ngẫu nhiên (ví dụ: 6 chữ số)
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void SendOTPToPhoneNumber(string phoneNumber, string otp)
        {
            ////Uyen
            //const string accountSid = "ACf491ea26074e7f0f799cbb46b20d0b83";
            //const string authToken = "f46a9ffca90f8c87c006dfb9b331a07e";
            ////Vi
            //const string accountSid = "AC513680079082812d0ee20f02315a50ff";
            //const string authToken = "5116bfaaa7277f01d309191758f71ff6";
            ////Vi 2
            ///
            const string accountSid = "AC741bf6d183805ce5cdcbd5cbbc3a9be7";
            const string authToken = "3e39128f6074480ef1d0e9b71e84680f";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(FormatPhoneNumber(phoneNumber));
            //var from = new PhoneNumber("+16622764010");
            //var from = new PhoneNumber("+16627096123");
            var from = new PhoneNumber("+17652524219");

            var message = MessageResource.Create(
                body: $"Your verification code for PET CARE AND ADOPTION is: {otp}",
                from: from,
                to: to
            );
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            // Kiểm tra xem số điện thoại có bắt đầu bằng "0" không
            if (phoneNumber.StartsWith("0"))
            {
                // Nếu có, thay thế "0" bằng "+84"
                return $"+84{phoneNumber.Substring(1)}";
            }
            else
            {
                // Nếu không, thêm "+84" vào đầu số điện thoại
                return $"+84{phoneNumber}";
            }
        }
    }
}
