using System.ComponentModel.DataAnnotations;

namespace PetCareAndAdoption.Models.Authentication
{
    public class ChangePasswordModel
    {
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
