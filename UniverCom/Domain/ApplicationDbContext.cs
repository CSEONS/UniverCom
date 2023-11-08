using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniverCom.Domain.Entities;

namespace UniverCom.Domain
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var users = new List<AppUser>()
            {
                new AppUser()
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(new AppUser(), "admin"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                }
            };

            var roles = new List<IdentityRole<Guid>>() 
            {
                new IdentityRole<Guid>()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole<Guid>()
                {
                    Id = Guid.NewGuid(),
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
                },
                new IdentityRole<Guid>()
                {
                    Id = Guid.NewGuid(),
                    Name = "Curator",
                    NormalizedName = "CURATOR"
                },
                new IdentityRole<Guid>()
                {
                    Id = Guid.NewGuid(),
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
            };

            var userRoles = new List<IdentityUserRole<Guid>>()
            {
                new IdentityUserRole<Guid>()
                {
                    RoleId = roles.First(r => r.Name == "Admin").Id,
                    UserId = users.First(u => u.UserName == "admin").Id
                }
            };

            builder.Entity<AppUser>().HasData(users);
            builder.Entity<IdentityRole<Guid>>().HasData(roles);
            builder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);

            base.OnModelCreating(builder);
        }
    }
}