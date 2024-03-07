using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentH2.Services.AuthAPI.Models;

namespace RentH2.Services.AuthAPI.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "408aa945-3d84-4421-8342-7269ec64d949",
                    Email = "admin@renth2.com",
                    NormalizedEmail = "ADMIN@RENTH2.COM",
                    NormalizedUserName = "ADMIN@RENTH2.COM",
                    UserName = "admin@renth2.com",
                    Name = "System",
                    SurName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "Admin123*"),
                    EmailConfirmed = true,
                    IdNumber = "5ABFFEAAEAE0",
                    //DateBirth = new DateTime(1980,1,3,DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
		            DriverLicenseId = "6D13ED6A-957A-4F94",
					DriverLicenseClass = "A+B",
					DriverLicenseImageUrl = string.Empty,
					DriverLicenseImageLocalPath = string.Empty

				},
                new ApplicationUser
				{
                    Id = "208aa945-2d84-2421-2342-2269ec64d949",
                    Email = "rider@renth2.com",
                    NormalizedEmail = "RIDER@RENTH2.COM",
                    NormalizedUserName = "RIDER@RENTH2.COM",
                    UserName = "rider@renth2.com",
					Name = "System",
					SurName = "Rider",
                    PasswordHash = hasher.HashPassword(null, "Admin123*"),
                    EmailConfirmed = true,
					IdNumber = "7AA4F3857AB9",
					//DateBirth = new DateTime(1980, 1, 3, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
					DriverLicenseId = "C5239363-957A-4F94",
					DriverLicenseClass = "B",
					DriverLicenseImageUrl = string.Empty,
					DriverLicenseImageLocalPath = string.Empty
				},
				new ApplicationUser
				{
					Id = "208dd945-2d84-2421-2342-2269fc54d949",
					Email = "rider02@renth2.com",
					NormalizedEmail = "RIDER02@RENTH2.COM",
					NormalizedUserName = "RIDER02@RENTH2.COM",
					UserName = "rider02@renth2.com",
					Name = "System",
					SurName = "Rider02",
					PasswordHash = hasher.HashPassword(null, "Admin123*"),
					EmailConfirmed = true,
					IdNumber = "8BB4F3857AC0",
					//DateBirth = new DateTime(1980, 1, 3, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
					DriverLicenseId = "D5239773-4F94-957A",
					DriverLicenseClass = "B",
					DriverLicenseImageUrl = string.Empty,
					DriverLicenseImageLocalPath = string.Empty
				}
			);
        }
    }
}