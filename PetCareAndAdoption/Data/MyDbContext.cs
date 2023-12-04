using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetCareAndAdoption.Data
{
    public class MyDbContext:IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }
        #region DbSet
        public DbSet<UserInfo>? Users { get; set; }
        #endregion

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<UserInfo>().HasData(
        //        new UserInfo { userID = "0393751403", name = "Uyen", address ="TD", password ="Binhaha32:))" }
        //    );
        //}
    }
}
