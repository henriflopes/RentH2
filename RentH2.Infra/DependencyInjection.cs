using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Domain.Repositories.Base.MongoDB.Interfaces;
using RentH2.Infrastructure.Configuration;
using RentH2.Infrastructure.Repositories;
using RentH2.Infrastructure.Repositories.Base.MongoDB;
using RentH2.Infrastructure.Repositories.Base.MongoDB.Interfaces;
using RentH2.Infrastructure.Repositories.Base.PostgreSQL;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Infrastructure.Services;
using RentH2.Infrastructure.Services.Contracts;
using RentH2.Infrastructure.Utility;
using EntityFramework.Exceptions.PostgreSQL;
using static RentH2.Common.Utility.SD;

namespace RentH2.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IHostApplicationBuilder builder, DataBaseType dataBaseType)
        {
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpContextAccessor();
            services.AddScoped<BackEndApiAuthenticationHttpClientHandler>();

            if (dataBaseType == DataBaseType.MongoDB)
            {
                services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
                services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                    serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value
                );
                services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
                services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
                services.AddScoped<IMotorcycleGateway, MotorcycleGateway>();
                services.AddScoped<IPlanRepository, PlanRepository>();
                services.AddScoped<IPlanGateway, PlanGateway>();
            }

            if (dataBaseType == DataBaseType.PostgreSQL)
            {
                services.AddDbContext<AppDbContext>(option =>
                {
                    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseExceptionProcessor();
                });
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            }

            services.AddScoped<IRentService, RentService>();
            services.AddHttpClient("Rent", q => q.BaseAddress = new Uri(builder.Configuration["ServiceUrls:RentAPI"]))
                .AddHttpMessageHandler<BackEndApiAuthenticationHttpClientHandler>();

            return services;
        }
    }
}
