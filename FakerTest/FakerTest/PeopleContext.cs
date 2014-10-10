namespace FakerTest
{
    using System.Data.Entity;

    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display-name");
        }
    }
}
