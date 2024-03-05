using Microsoft.EntityFrameworkCore;
using RentH2.Services.MotorcycleAPI.Models;
using MongoDB.Driver;

namespace RentH2.Services.MotorcycleAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Motorcycle> Motorcycles { get; init; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Motorcycle>();
		}
	}
}
