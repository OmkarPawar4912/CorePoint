using CorePoint.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CorePoint.DAL.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
    }
}
