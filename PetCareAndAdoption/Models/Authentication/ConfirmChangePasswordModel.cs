namespace PetCareAndAdoption.Models.Authentication
{
    public class ConfirmChangePasswordModel
    {
        public string PhoneNumber { get; set; } = null!;
        public string OTP { get; set; }
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
