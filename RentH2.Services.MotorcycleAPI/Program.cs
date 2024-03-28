using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using RentH2.Services.MotorcycleAPI.Extensions;
using RentH2.Services.MotorcycleAPI.Utility;
using RentH2.Services.MotorcycleAPI;
using RentH2.Services.MotorcycleAPI.Services;
using RentH2.Services.MotorcycleAPI.Services.IService;
using RentH2.Web.Services.IServices;
using RentH2.Application;
using RentH2.Domain.Contracts;
using RentH2.Infra.Repositories;
using RentH2.Infra.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using RentH2.Infra.Repositories.Base.MongoDB.Interfaces;
using RentH2.Infra.Repositories.Base.MongoDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
builder.Services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
builder.Services.AddScoped<IMotorcycleGateway, MotorcycleGateway>();

builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
builder.Services.AddScoped<IRidersRentsService, RidersRentsService>();
builder.Services.AddHttpClient("RidersRents", q => q.BaseAddress = new Uri(builder.Configuration["ServiceUrls:RidersRentsAPI"])).AddHttpMessageHandler<BackEndApiAuthenticationHttpClientHandler>();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<BackEndApiAuthenticationHttpClientHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
	option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Description = "Enter the Bearer Authorization string as following: 'Bearer Generated-JWT-Token'",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});
	option.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = JwtBearerDefaults.AuthenticationScheme
				}
			}, new string[]{ }
		}
	});
});

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<ApplicationMediatREntryPoint>());

builder.AddAppAuthentication();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
	app.UseSwaggerUI();
}
else
{
	app.UseSwaggerUI(c => {
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Motorcycle API");
		c.RoutePrefix = string.Empty;
	});
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();