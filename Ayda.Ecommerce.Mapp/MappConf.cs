using AutoMapper;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.Domains.User;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.Role;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.Mapp;

public class MappConf : Profile {
    public static MapperConfiguration RegisterMaps() {
        var mappingConfig = new MapperConfiguration(config => {
            config.CreateMap<Category, CategoryDto>()
                .ForMember(p => p.SubCategories,
                    p => p.MapFrom(q => q.SubCategories))
                .ForMember(p => p.ParentCategory,
                    p => p.MapFrom(q => q.ParentCategory))
                .ForMember(p => p.CategoryAttributes,
                    p => p.MapFrom(q => q.CategoryAttributes));

            config.CreateMap<CategoryDto, Category>()
                .ForMember(p => p.SubCategories,
                    p => p.MapFrom(q => q.SubCategories))
                .ForMember(p => p.ParentCategory,
                    p => p.MapFrom(q => q.ParentCategory))
                .ForMember(p => p.CategoryAttributes,
                    p => p.MapFrom(q => q.CategoryAttributes));
            config.CreateMap<Category, CreateCategoryDto>().ReverseMap();
            config.CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            //Role
            config.CreateMap<Role, RoleDto>()
                .ForMember(p => p.ApplicationUsers,
                p => p.MapFrom(q => q.ApplicationUsers));
            config.CreateMap<RoleDto, Role>()
                .ForMember(p => p.ApplicationUsers,
                p => p.MapFrom(q => q.ApplicationUsers));
            config.CreateMap<CreateRoleDto, Role>().ReverseMap();

            //User
            config.CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(p => p.Role,
                    p => p.MapFrom(q => q.Role));
            config.CreateMap<ApplicationUserDto, ApplicationUser>()
                .ForMember(p => p.Role,
                    p => p.MapFrom(q => q.Role));
            config.CreateMap<ApplicationUser, CreateApplicationUserDto>().ReverseMap();
            config.CreateMap<ApplicationUser, RegisterApplicationUserDto>().ReverseMap();
        });
        return mappingConfig;
    }
}