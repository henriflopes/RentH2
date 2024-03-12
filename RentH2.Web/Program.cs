using RentH2.Web.Service;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using RentH2.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IMotorcycleService, MotorcycleService>();
builder.Services.AddHttpClient<IPlanService, PlanService>();

//builder.Services.AddHttpClient<IProductService, ProductService>();
//builder.Services.AddHttpClient<ICartService, CartService>();
//builder.Services.AddHttpClient<IOrderService, OrderService>();

SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"] + "/api/product/" ;
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"] + "/api/auth/";
SD.ShoppingCartAPIBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"] + "/api/shoppingcart/";
SD.OrderAPIBase = builder.Configuration["ServiceUrls:OrderAPI"] + "/api/order/";
SD.RentAPIBase = builder.Configuration["ServiceUrls:RentAPI"] + "/api/rent/";
SD.MotorcycleAPIBase = builder.Configuration["ServiceUrls:MotorcycleAPI"] + "/api/motorcycle/";
SD.PlanAPIBase = builder.Configuration["ServiceUrls:PlanAPI"] + "/api/plan/";

builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPlanService, PlanService>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.ExpireTimeSpan = TimeSpan.FromHours(10);
		options.LoginPath = "/Auth/Login";
		options.AccessDeniedPath = "/Auth/AccessDenied";
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();