using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("PetImages")]
    public class PetImages
    {
        [Key]
        public string imgPetID { get; set; }
        public string petID { get; set; }
        public string image { get; set; }
    }
}
