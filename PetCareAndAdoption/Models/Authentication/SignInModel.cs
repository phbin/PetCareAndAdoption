using System.ComponentModel.DataAnnotations;

namespace PetCareAndAdoption.Models.Authentication
{
    public class SignInModel
    {
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
