using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RentH2.Services.EmailAPI.Services;
using RentH2.Services.NotificationAPI.Messaging;
using RentH2.Services.NotificationAPI.Services.IServices;
using RentH2.Services.NotificationAPI.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//{
//    Value.
//    //ConnectionString = builder.Configuration["MongoDataBase:ConnectionString"],
//    //DatabaseName = builder.Configuration["MongoDataBase:DatabaseName"],
//    //CollectionName = builder.Configuration["MongoDataBase:CollectionName"]
//};

builder.Services.AddDbContext<DatabaseSettings>(option =>
{
    option.UseMongoDB(
        builder.Configuration["MongoDataBase:ConnectionString"],
        builder.Configuration["MongoDataBase:DatabaseName"]
    );
});

builder.Services.AddHostedService<RabbitMQOrderConsumer>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<INotificationService, NotificationService>();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDataBase"));

//builder.Services.AddSingleton(new NotificationService(options));

//builder.Services.AddSingleton(new EmailService(optionBuilder.Options));
//builder.Services.AddSingleton(new NotificationService());

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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification API");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
