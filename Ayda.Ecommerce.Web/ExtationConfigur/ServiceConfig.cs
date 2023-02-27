using AutoMapper;
using Ayda.Ecommerce.App;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.App.Services.Repository;
using Ayda.Ecommerce.Mapp;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Ayda.Ecommerce.Web.ExtationConfigur;

public static class ServiceConfig
{
    public static IServiceCollection RegisteratinServices(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddAuthorization(options => {
	        options.AddPolicy(SD.Role_Admin, policy => policy.RequireRole(SD.Role_Admin));
	        options.AddPolicy(SD.Role_Employee, policy => policy.RequireRole(SD.Role_Employee));
        });

        services.AddAuthentication(options => {
	        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(options => {
	        options.LoginPath = new PathString("/Auth/Login");
	        options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
	        options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
        });
		services.AddScoped<IUnitOfWork, UnitOfWork>();
        IMapper mapper = MappConf.RegisterMaps().CreateMapper();
        services.AddSingleton(mapper);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}