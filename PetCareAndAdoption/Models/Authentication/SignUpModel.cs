using System.ComponentModel.DataAnnotations;

namespace PetCareAndAdoption.Models.Authentication
{
    public class SignUpModel
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string District { get; set; } = null!;
        public string Province { get; set; } = null!;
        [Required, Phone]
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
