
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.App.Services.Repository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var CtxConStr = builder.Configuration.GetConnectionString("DbConnection");


builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(CtxConStr));
builder.Services.RegisteratinServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
