using ASPNetCoreWebAPIClass.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPIClass.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<User>();

            //create a role
            builder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });

            //create a user
            builder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   UserName = "ecommerceadmin",
                   NormalizedUserName = "ECOMMERCEADMIN",
                   PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                   FirstName = "Admin",
                   LastName = "Admin",
                   Email = "ecommerceadmin@gmail.com",
                   NormalizedEmail = "ECOMMERCEADMIN@GMAIL.COM"

               }
               );

            //asign admin role to the user we created
            builder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = 1,
                UserId = 1

            });
        }

    }
}
