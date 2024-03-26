using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using RentH2.Services.RentAPI.Extensions;
using RentH2.Services.RentAPI.Utility;
using RentH2.Services.RentAPI;
using RentH2.Services.RentAPI.Services.IService;
using RentH2.Services.RentAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDataBase"));

builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<IRidersRentsService, RidersRentsService>();
builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddHttpClient("Plan", q => q.BaseAddress = new Uri(builder.Configuration["ServiceUrls:PlanAPI"])).AddHttpMessageHandler<BackEndApiAuthenticationHttpClientHandler>();
builder.Services.AddHttpClient("Motorcycle", q => q.BaseAddress = new Uri(builder.Configuration["ServiceUrls:MotorcycleAPI"])).AddHttpMessageHandler<BackEndApiAuthenticationHttpClientHandler>();

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
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rent API");
		c.RoutePrefix = string.Empty;
	});
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();