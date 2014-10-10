namespace FakerTest
{
    using System.Data.Entity;

    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
