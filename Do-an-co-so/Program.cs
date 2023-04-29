using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Do_an_co_so.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Do_an_co_soContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Do_an_co_soContext") ?? throw new InvalidOperationException("Connection string 'Do_an_co_soContext' not found.")));


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
