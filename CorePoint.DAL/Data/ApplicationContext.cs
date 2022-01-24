using CorePoint.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CorePoint.DAL.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentStatus> IncidentStatuses { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
    }
}
