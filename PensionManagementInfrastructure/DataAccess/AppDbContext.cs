using Microsoft.EntityFrameworkCore;
using PensionManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.DataAccess
{
    public class AppDbContext: DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Benefit> Benefits { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Member to contribution
            modelBuilder.Entity<Member>()
                .HasMany(m => m.Contributions)
                .WithOne(c => c.Member)
                .HasForeignKey(c => c.MemberId);

            // Member to benefit
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Benefit)
                .WithOne(b => b.Member)
                .HasForeignKey<Benefit>(b => b.MemberId);

            modelBuilder.Entity<Benefit>()
            .Property(b => b.Amount)
            .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Contribution>()
                .Property(c => c.Amount)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Member>()
                .Property(m => m.TotalContribution)
                .HasColumnType("decimal(18,4)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
