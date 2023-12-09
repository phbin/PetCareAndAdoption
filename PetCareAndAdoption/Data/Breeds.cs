using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("Breeds")]
    public class Breeds
    {
        [Key]
        public string ?breedID { get; set; }
        public string ?speciesID { get; set; }
        public Species Species { get; set; } = null!;
        public string ?breedName { get; set; } 
    }
}
