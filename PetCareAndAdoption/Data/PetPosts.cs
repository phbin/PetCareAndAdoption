using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("PetPosts")]
    public class PetPosts
    {
        [Key]
        public string postID { get; set; }       
        public string petName { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string species { get; set; }
        public string breed { get; set; }
        public string weight { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string description { get; set; }
        public bool isVaccinated { get; set; }
        public bool isAdopt { get; set; }
        public bool isDone { get; set; }
        public string userID { get; set; }
    }
}
