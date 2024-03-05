using RentH2.Services.AuthAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentH2.Services.AuthAPI.Models;
using RentH2.Services.AuthAPI.RabbitMQSender;
using RentH2.Services.AuthAPI.Service;
using RentH2.Services.AuthAPI.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
	option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRabbitMQAuthMessageSender, RabbitMQAuthMessageSender>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
	app.UseSwaggerUI();
}
else
{
	app.UseSwaggerUI(c => {
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API");
		c.RoutePrefix = string.Empty;
	});
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ApplyMigration();

app.Run();

void ApplyMigration()
{
	using (var scope = app.Services.CreateScope())
	{
		var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

		if (_db.Database.GetPendingMigrations().Count() > 0)
		{
			_db.Database.Migrate();
		}
	}
}
