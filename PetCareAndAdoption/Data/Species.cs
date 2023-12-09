using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("Species")]
    public class Species
    {
        [Key]
        public string speciesID { get; set; }
        public string speciesName { get; set; }
        public ICollection<Breeds> Breeds { get; } = new List<Breeds>();
    }
}
