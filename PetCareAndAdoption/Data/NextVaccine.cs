using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("NextVaccine")]
    public class NextVaccine
    {
        [Key]
        public string nextVaccineID { get; set; }
        public string petID { get; set; }
        public string date { get; set; }
        public string note { get; set; }
    }
}
