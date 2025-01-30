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
            modelBuilder.Entity<Member>().HasKey(x => x.Id);

        }

    }
}
