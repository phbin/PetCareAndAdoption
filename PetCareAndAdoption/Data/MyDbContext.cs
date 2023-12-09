using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace PetCareAndAdoption.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }
        #region DbSet
        public DbSet<UserInfo>? Users { get; set; }
        public DbSet<Species>? Species { get; set; }
        public DbSet<Breeds>? Breeds { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Guid newGuid1 = Guid.NewGuid();
            Guid newGuid2 = Guid.NewGuid();
            Guid newGuid3 = Guid.NewGuid();


            modelBuilder.Entity<Species>()
        .HasMany(e => e.Breeds)
        .WithOne(e => e.Species)
        .HasForeignKey(e => e.speciesID)
            .IsRequired();

            modelBuilder.Entity<Breeds>()
        .HasOne(e => e.Species)
        .WithMany(e => e.Breeds)
        .HasForeignKey(e => e.speciesID)
        .IsRequired();

            modelBuilder.Entity<Species>().HasData(
                new Species { speciesID = newGuid1.ToString(), speciesName = "Cat" },
                new Species { speciesID = newGuid2.ToString(), speciesName = "Dog" },
                new Species { speciesID = newGuid3.ToString(), speciesName = "Others" }
            );

            // Thêm breeds mới
            modelBuilder.Entity<Breeds>().HasData(
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Bird" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Hamster" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Chicken" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Hedgehog" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Rabbit" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Turtle" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Tortoise" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Snake" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Fish" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Monkey" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid3.ToString(), breedName = "Others" }
            );
            modelBuilder.Entity<Breeds>().HasData(
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Bulldog" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Labrador" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Golden Retriever" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "German Shepherd" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Beagle" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Poodle" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Boxer" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Dachshund" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Shih Tzu" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Siberian Husky" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Chihuahua" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Great Dane" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Corgi" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Shetland Sheepdog" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Doberman Pinscher" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Basset Hound" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Bernese Mountain Dog" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Maltese" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Pug" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid2.ToString(), breedName = "Dalmatian" },


                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Persian" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Siamese" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Maine Coon" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Ragdoll" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Bengal" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Sphynx" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Scottish Fold" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "British Shorthair" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Abyssinian" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Russian Blue" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Burmese" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Norwegian Forest" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Egyptian Mau" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Devon Rex" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Balinese" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Oriental Shorthair" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Cornish Rex" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Turkish Angora" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Himalayan" },
                new Breeds { breedID = Guid.NewGuid().ToString(), speciesID = newGuid1.ToString(), breedName = "Exotic Shorthair" }
                );
           
            //modelBuilder.Entity<Species>().HasData(
            //    new { speciesID = newGuid1, careGuideID = "NewCareGuideForCats" }
            //);
        }
    }
}
