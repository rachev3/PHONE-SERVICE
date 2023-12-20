using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PHONE_SERVICE.Data.DTO;
using System.Security.Cryptography.X509Certificates;

namespace PHONE_SERVICE.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PhoneModel> PhoneModels { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }
        public DbSet<PhoneModelRepair> PhoneModelsRepair { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasMany(u => u.ClientRepairRequests)
            .WithOne(rr => rr.ClientUser)
            .HasForeignKey(rr => rr.ClientUserId)
            .OnDelete(DeleteBehavior.Restrict);
            

            modelBuilder.Entity<User>()
                .HasMany(u => u.WorkerRepairRequests)
                .WithOne(rr => rr.WorkerUser)
                .HasForeignKey(rr => rr.WorkerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RepairRequest>()
                .HasOne(r=>r.WorkerUser)
                .WithMany(r=>r.WorkerRepairRequests)
                .HasForeignKey(r=>r.WorkerUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RepairRequest>()
               .HasOne(r => r.ClientUser)
               .WithMany(r => r.ClientRepairRequests)
               .HasForeignKey(r => r.ClientUserId)
               .OnDelete(DeleteBehavior.NoAction);


        }
    }
}