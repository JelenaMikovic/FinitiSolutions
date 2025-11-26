using Microsoft.EntityFrameworkCore;

namespace nvt_back
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
         

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "bob@mail.com", Password = "123", Role = UserRole.USER } ,
                new User { Id = 2, Email = "ross@mail.com", Password = "123", Role = UserRole.ADMIN }
            );

        }

    }
}
