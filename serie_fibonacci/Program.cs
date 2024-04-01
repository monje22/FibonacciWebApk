using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using serie_fibonacci.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<serie_fibonacciContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("serie_fibonacciContext") ?? throw new InvalidOperationException("Connection string 'serie_fibonacciContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fibonaccis}/{action=Index}/{id?}");

app.Run();
