﻿namespace PetCareAndAdoption.Models.Posts
{
    public class PostUpdateModel
    {
        public string petName { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public string species { get; set; }
        public string breed { get; set; }
        public string weight { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string description { get; set; }
        public bool isVaccinated { get; set; }
        public bool isAdopt { get; set; }
    }
}
