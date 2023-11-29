using System.ComponentModel.DataAnnotations;

namespace PetCareAndAdoption.Models.Authentication
{
    public class SignUpModel
    {
        [Required, Phone]
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string Birthday { get; set; } = null!;
    }
}
