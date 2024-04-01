using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RentH2.Domain.Contracts;
using RentH2.Domain.Repositories.Base.MongoDB.Interfaces;
using RentH2.Infrastructure.Configuration;
using RentH2.Infrastructure.Repositories;
using RentH2.Infrastructure.Repositories.Base.MongoDB;
using RentH2.Infrastructure.Repositories.Base.MongoDB.Interfaces;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Infrastructure.Services;
using RentH2.Infrastructure.Services.Contracts;
using RentH2.Infrastructure.Utility;

namespace RentH2.Infrastructure
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

            services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value
            );
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            services.AddScoped<IMotorcycleGateway, MotorcycleGateway>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IPlanGateway, PlanGateway>();

            services.AddScoped<IRentService, RentService>();
            services.AddHttpClient("Rent", q => q.BaseAddress = new Uri(builder.Configuration["ServiceUrls:RentAPI"]))
                .AddHttpMessageHandler<BackEndApiAuthenticationHttpClientHandler>();

            return services;
        }
    }
}
