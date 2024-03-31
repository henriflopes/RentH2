using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RentH2.Domain.Contracts;
using RentH2.Infra.Configuration;
using RentH2.Infra.Repositories;
using RentH2.Infra.Repositories.Base.MongoDB;
using RentH2.Infra.Repositories.Base.MongoDB.Interfaces;
using RentH2.Infra.Repositories.Interfaces;
using RentH2.Infra.Services;
using RentH2.Infra.Services.Contracts;
using RentH2.Infra.Utility;

namespace RentH2.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IHostApplicationBuilder builder) 
        {
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();
            services.AddScoped<BackEndApiAuthenticationHttpClientHandler>();

            // Add services to the container.
            services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value
            );
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            services.AddScoped<IMotorcycleGateway, MotorcycleGateway>();

            services.AddScoped<IRidersRentsService, RidersRentsService>();
            services.AddHttpClient("RidersRents", q => q.BaseAddress = new Uri(builder.Configuration["ServiceUrls:RidersRentsAPI"])).AddHttpMessageHandler<BackEndApiAuthenticationHttpClientHandler>();

            return services;
        }
    }
}
