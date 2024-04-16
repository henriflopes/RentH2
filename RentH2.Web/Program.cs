using RentH2.Web.Service;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using RentH2.Web.Services;
using System.Globalization;
using System.Security.AccessControl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc()
        .AddViewLocalization()
        .AddDataAnnotationsLocalization();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IMotorcycleService, MotorcycleService>();
builder.Services.AddHttpClient<IPlanService, PlanService>();
builder.Services.AddHttpClient<IRentService, RentService>();
builder.Services.AddHttpClient<IOrderService, OrderService>();
//builder.Services.AddHttpClient<IProductService, ProductService>();
//builder.Services.AddHttpClient<ICartService, CartService>();


SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"] + "/api/product/" ;
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"] + "/api/auth/";
SD.ShoppingCartAPIBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"] + "/api/shoppingcart/";
SD.OrderAPIBase = builder.Configuration["ServiceUrls:OrderAPI"] + "/api/order/";
SD.RentAPIBase = builder.Configuration["ServiceUrls:RentAPI"] + "/api/rent/";
RentH2.Domain.Utility.SD.MotorcycleAPIBase = builder.Configuration["ServiceUrls:MotorcycleAPI"] + "/api/motorcycle/";
SD.PlanAPIBase = builder.Configuration["ServiceUrls:PlanAPI"] + "/api/plan/";

builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<IOrderService, OrderService>();


//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ICartService, CartService>();

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
//SetCulture();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//static void SetCulture()
//{
//    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

//    var culture = CultureInfo.CreateSpecificCulture("pt-BR");

//    Thread.CurrentThread.CurrentCulture = culture;
//    Thread.CurrentThread.CurrentUICulture = culture;
//}