using CIS236_Contact_Manager.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using ContextList.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Custom configuration for routing
builder.Services.AddRouting(options => {
	options.LowercaseUrls = true;
	options.AppendTrailingSlash = true;
});

// Add DbContext for ContactContext
builder.Services.AddDbContext<ContactContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext")));

//build app
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
