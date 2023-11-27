using Microsoft.EntityFrameworkCore;

namespace PetCareAndAdoption.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }
        #region DbSet
        public DbSet<UserInfo>? Users { get; set; }
        #endregion 
    }
}
