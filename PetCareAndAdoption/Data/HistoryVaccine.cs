using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("HistoryVaccine")]
    public class HistoryVaccine
    {
        [Key]
        public string historyVaccineID { get; set; }
        public string petID { get; set; }
        public string date { get; set; }
        public string note { get; set; }
    }
}
