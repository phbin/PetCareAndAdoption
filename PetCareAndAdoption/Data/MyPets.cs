using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table ("MyPets")]
    public class MyPets
    {
        [Key]
        public string petID { get; set; }
        public string petName { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string species { get; set; }
        public string breed { get; set; }
        public string weight { get; set; }
        public string description { get; set; }
        public string userID { get; set; }
    }
}
