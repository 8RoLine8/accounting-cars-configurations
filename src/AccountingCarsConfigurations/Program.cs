using AccountingCarsConfigurations.Data;
using AccountingCarsConfigurations.Data.Repositories;
using AccountingCarsConfigurations.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AccountingCarsConfigurationsContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ManufacturerRepository>();
builder.Services.AddScoped<BodyTypeRepository>();
builder.Services.AddScoped<ModelRepository>();
builder.Services.AddScoped<CarRepository>();
builder.Services.AddScoped<ConfigurationRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ModificationRepository>();
builder.Services.AddScoped<ConfigurationSetRepository>();
builder.Services.AddScoped<ConfigurationCompositionRepository>();
builder.Services.AddScoped<ReportsRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options => { options.LoginPath = "/Auth"; });

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
	pattern: "{controller=Cars}/{action=Index}");

app.Run();
