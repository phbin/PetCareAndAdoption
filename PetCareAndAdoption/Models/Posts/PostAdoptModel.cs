namespace PetCareAndAdoption.Models.Posts
{
    public class PostAdoptModel
    {
        public string postID { get; set; }
        public string petName { get; set; }
        public string sex { get; set; }
        public string species { get; set; }
        public string breed { get; set; }
        public string weight { get; set; }
        public string latLocation { get; set; }
        public string destLocation { get; set; }
        public string nameLocation { get; set; }
        public bool isVaccinated { get; set; }
        public bool isAdopt { get; set; }
        public string targetFee { get; set; }
        public bool isDone { get; set; }
        public string userID { get; set; }
    }
}
