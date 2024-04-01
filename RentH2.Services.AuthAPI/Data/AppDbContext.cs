using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentH2.Services.AuthAPI.Configurations.Entities;
using RentH2.Services.AuthAPI.Models;

namespace RentH2.Services.AuthAPI.Data
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ApplicationUser>().HasAlternateKey(a => new { a.DocumentId });
			builder.Entity<ApplicationUser>().HasAlternateKey(a => new { a.DriverLicenseId });
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new RoleSeedConfiguration());
			builder.ApplyConfiguration(new UserSeedConfiguration());
			builder.ApplyConfiguration(new UserRoleSeedConfiguration());
		}
	}
}
