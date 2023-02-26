using AutoMapper;
using Ayda.Ecommerce.App;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.App.Services.Repository;
using Ayda.Ecommerce.Mapp;

namespace Ayda.Ecommerce.Web.ExtationConfigur;

public static class ServiceConfig
{
    public static IServiceCollection RegisteratinServices(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        IMapper mapper = MappConf.RegisterMaps().CreateMapper();
        services.AddSingleton(mapper);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}