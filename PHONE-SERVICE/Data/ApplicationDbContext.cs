using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PHONE_SERVICE.Data.DTO;
using System.Security.Cryptography.X509Certificates;

namespace PHONE_SERVICE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PhoneModel> PhoneModels { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

        }
    }
}