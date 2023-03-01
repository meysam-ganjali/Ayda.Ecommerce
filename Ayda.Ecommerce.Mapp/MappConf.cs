using AutoMapper;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.Domains.User;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductComment;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductImage;
using Ayda.Ecommerce.ShareModels.Role;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.Mapp;

public class MappConf : Profile {
    public static MapperConfiguration RegisterMaps() {

        var mappingConfig = new MapperConfiguration(config => {
            #region Category Mapp


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
            #endregion

            #region Role Mapp

            //Role
            config.CreateMap<Role, RoleDto>()
                .ForMember(p => p.ApplicationUsers,
                p => p.MapFrom(q => q.ApplicationUsers));
            config.CreateMap<RoleDto, Role>()
                .ForMember(p => p.ApplicationUsers,
                p => p.MapFrom(q => q.ApplicationUsers));
            config.CreateMap<CreateRoleDto, Role>().ReverseMap();

            #endregion

            #region User Mapp

            //User
            config.CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(p => p.Role,
                    p => p.MapFrom(q => q.Role));
            config.CreateMap<ApplicationUserDto, ApplicationUser>()
                .ForMember(p => p.Role,
                    p => p.MapFrom(q => q.Role));
            config.CreateMap<ApplicationUser, CreateApplicationUserDto>().ReverseMap();
            config.CreateMap<ApplicationUser, RegisterApplicationUserDto>().ReverseMap();

            #endregion

            #region Product Mapp

            config.CreateMap<Product, ProductDto>()
                .ForMember(p => p.Category,
                    p => p.MapFrom(q => q.Category))
                .ForMember(p => p.ProductColors,
                    p => p.MapFrom(q => q.ProductColors))
                .ForMember(p => p.ProductComments,
                    p => p.MapFrom(q => q.ProductComments))
                .ForMember(p => p.ProductImages,
                    p => p.MapFrom(q => q.ProductImages))
                .ForMember(p => p.ProductAttributes,
                    p => p.MapFrom(q => q.ProductAttributes));
            config.CreateMap<ProductDto, Product>()
                .ForMember(p => p.Category,
                    p => p.MapFrom(q => q.Category))
                .ForMember(p => p.ProductColors,
                    p => p.MapFrom(q => q.ProductColors))
                .ForMember(p => p.ProductComments,
                    p => p.MapFrom(q => q.ProductComments))
                .ForMember(p => p.ProductImages,
                    p => p.MapFrom(q => q.ProductImages))
                .ForMember(p => p.ProductAttributes,
                    p => p.MapFrom(q => q.ProductAttributes));
            config.CreateMap<Product, CreateProductDto>().ReverseMap();
            config.CreateMap<Product, UpdateProductDto>().ReverseMap();

            #endregion

            #region Category Attribute Mapp

            config.CreateMap<CategoryAttribute, CategoryAttributeDto>()
                .ForMember(p => p.CategoryId,
                    p => p.MapFrom(q => q.Category))
                .ForMember(p => p.ProductAttributes,
                    p => p.MapFrom(q => q.ProductAttributes));
            config.CreateMap<CategoryAttributeDto, CategoryAttribute>()
                .ForMember(p => p.CategoryId,
                    p => p.MapFrom(q => q.Category))
                .ForMember(p => p.ProductAttributes,
                    p => p.MapFrom(q => q.ProductAttributes));
            config.CreateMap<CategoryAttribute, CreateCategoryAttributeDto>().ReverseMap();
            config.CreateMap<CategoryAttribute, UpdateCategoryAttributeDto>().ReverseMap();

            #endregion

            #region Product Attribute Mapp

            config.CreateMap<ProductAttribute, ProductAttributeDto>()
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product))
                .ForMember(p => p.CategoryAttribute,
                    p => p.MapFrom(q => q.CategoryAttribute));

            config.CreateMap<ProductAttribute, ProductAttributeDto>()
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product))
                .ForMember(p => p.CategoryAttribute,
                    p => p.MapFrom(q => q.CategoryAttribute));
            config.CreateMap<ProductAttribute, CreateProductAttributeDto>().ReverseMap();
            config.CreateMap<ProductAttribute, UpdateProductAttributeDto>().ReverseMap();

            #endregion

            #region Product Color Mapp

            config.CreateMap<ProductColor, ProductColorDto>()
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product));
            config.CreateMap<ProductColorDto, ProductColor>()
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product));

            config.CreateMap<ProductColor, CreateProductColorDto>().ReverseMap();
            config.CreateMap<ProductColor, UpdateProductColorDto>().ReverseMap();

            #endregion

            #region Product Comment Mapp

            config.CreateMap<ProductComment, ProductCommentDto>()
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product))
                .ForMember(p => p.ApplicationUser,
                    p => p.MapFrom(q => q.ApplicationUser));
            config.CreateMap<ProductCommentDto, ProductComment>()
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product))
                .ForMember(p => p.ApplicationUser,
                    p => p.MapFrom(q => q.ApplicationUser));

            config.CreateMap<ProductComment, CreateProductCommentDto>().ReverseMap();

            #endregion

            #region Product Image Mapp

            config.CreateMap<ProductImage, ProductImageDto>()
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product));
            config.CreateMap<ProductImageDto, ProductImage>()
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product));

            config.CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();

            #endregion
        });
        return mappingConfig;
    }
}