using Entity.Entities;
using Entity.MemberShip;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DataContext:IdentityDbContext<AppUser,AppRole,int,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
                
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRole>()
                .HasData(
                new AppRole { Id = 1, Name = "admin", NormalizedName = "ADMIN", ConcurrencyStamp = null });
            base.OnModelCreating(modelBuilder);
        }
    }
}
