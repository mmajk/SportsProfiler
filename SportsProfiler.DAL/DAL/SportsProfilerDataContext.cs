using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsProfiler.Models.Models;

namespace SportsProfiler.DAL.DAL
{
    public class SportsProfilerDataContext : DbContext
    {
        public SportsProfilerDataContext()
        {
            
        } 
  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User
            builder.Entity<User>().HasKey(x => x.UserId);
            builder.Entity<User>().Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(x => x.Email).IsRequired().HasMaxLength(100);
            
            // Address

            builder.Entity<Address>().HasKey(x => x.AddressId);
            builder.Entity<Address>().HasOne<User>().WithMany(x => x.Addresses)
                .HasForeignKey(x => x.UserId);
            
            // UserRoles
            builder.Entity<UserRoles>().HasKey(x => x.UserRoleId);
            builder.Entity<UserRoles>().Property(x => x.UserId).IsRequired();
            builder.Entity<UserRoles>().Property(x => x.RoleId).IsRequired();



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=SportsProfilerDb;user=jk;password=jk@123");
        }
  
        public virtual void Save()  
        {  
            base.SaveChanges();  
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())  
        {  
            return await base.SaveChangesAsync(cancellationToken);  
        }

        public DbSet<User> SportsProfilerUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> UserRoles { get; set; }
        public DbSet<UserRoles> UserRoleJunctions { get; set; }
        

    }
}