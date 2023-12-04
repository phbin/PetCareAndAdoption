namespace PetCareAndAdoption.Models.Authentication
{
    public class ConfirmSignUpModel
    {
        public string OTP { get; set; }
        public SignUpModel SignUpModel { get; set; }
    }
}
