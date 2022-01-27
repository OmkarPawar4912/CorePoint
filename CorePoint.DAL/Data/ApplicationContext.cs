using CorePoint.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CorePoint.DAL.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedCountry(builder);
            SeedState(builder);
            SeedCity(builder);
            SeedAddress(builder);
            SeedCrew(builder);
            SeedUsers(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);
        }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentStatus> IncidentStatuses { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }

        private void SeedCrew(ModelBuilder builder)
        {
            builder.Entity<Crew>().HasData(new Crew { ID = 1, Name = "N/A", Code = "N/A", Sitecode = "N/A" });
        }
        private void SeedAddress(ModelBuilder builder)
        {
            builder.Entity<Address>().HasData(new Address { Id = 1, AddressLine = "N/A", CountryId = 1, StateId = 1,CityId=1 }) ;
        }
        private void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            Employee emp = new Employee()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail= "ADMIN@GMAIL.COM",
                NormalizedUserName= "ADMIN@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                AddressId = 1,
                CrewId = 1
            };
            builder.Entity<Employee>().HasData(emp);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "2", Name = "Supervisior", ConcurrencyStamp = "2", NormalizedName = "Supervisior" },
                new IdentityRole() { Id = "3", Name = "Employee", ConcurrencyStamp = "3", NormalizedName = "Employee" }
               );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "1", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }

        private void SeedCountry(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "India" },
                new Country { Id = 2, Name = "USA" },
                new Country { Id = 3, Name = "Japan" });
        }

        private void SeedState(ModelBuilder builder)
        {
            builder.Entity<State>().HasData(
                new State { Id = 1, Name = "Maharatra", CountryId = 1 },
                new State { Id = 2, Name = "Goa", CountryId = 1 },
                new State { Id = 3, Name = "Andhra Pradesh", CountryId = 1 },
                new State { Id = 4, Name = "New York", CountryId = 2 },
                new State { Id = 5, Name = "Buffalo", CountryId = 2 },
                new State { Id = 6, Name = "Fukuoka", CountryId = 3 },
                new State { Id = 7, Name = "Gumma", CountryId = 3 },
                new State { Id = 8, Name = "Aichi", CountryId = 3 });
        }

        private void SeedCity(ModelBuilder builder)
        {
            builder.Entity<City>().HasData(
                new City { Id = 1, Name = "Sangli", StateId = 1 },
                new City { Id = 2, Name = "Miraj", StateId = 1 },
                new City { Id = 3, Name = "Kolhapur", StateId = 1 },
                new City { Id = 4, Name = "Bronx", StateId = 4 },
                new City { Id = 5, Name = "Kings", StateId = 4 },
                new City { Id = 6, Name = "Queens", StateId = 4 },
                new City { Id = 7, Name = "Sapporo", StateId = 5 });
        }

    }
}
