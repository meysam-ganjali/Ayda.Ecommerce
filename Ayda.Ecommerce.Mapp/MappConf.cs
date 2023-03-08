using AutoMapper;
using Ayda.Ecommerce.Domains.Cart;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.Domains.Menu;
using Ayda.Ecommerce.Domains.Slider;
using Ayda.Ecommerce.Domains.User;
using Ayda.Ecommerce.ShareModels.Carts;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductComment;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductImage;
using Ayda.Ecommerce.ShareModels.Menu;
using Ayda.Ecommerce.ShareModels.Role;
using Ayda.Ecommerce.ShareModels.Slider;
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
                .ForMember(p => p.Category,
                    p => p.MapFrom(q => q.Category))
                .ForMember(p => p.ProductAttributes,
                    p => p.MapFrom(q => q.ProductAttributes));
            config.CreateMap<CategoryAttributeDto, CategoryAttribute>()
                .ForMember(p => p.Category,
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

            #region Slider Mapp

            config.CreateMap<Slider, SliderDto>()
                .ForMember(p => p.Possition,
                    p => p.MapFrom(q => q.Possition));
            config.CreateMap<SliderDto, Slider>()
                .ForMember(p => p.Possition,
                    p => p.MapFrom(q => q.Possition));
            config.CreateMap<Slider, CreateSliderDto>().ReverseMap();
            config.CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            #endregion

            #region Banner Mapp

            config.CreateMap<Banner, BannerDto>()
                .ForMember(p => p.Possition,
                    p => p.MapFrom(q => q.Possition));
            config.CreateMap<BannerDto, Banner>()
                .ForMember(p => p.Possition,
                    p => p.MapFrom(q => q.Possition));
            config.CreateMap<Banner, CreateBannerDto>().ReverseMap();
            config.CreateMap<Banner, UpdateBannerDto>().ReverseMap();

            #endregion

            #region Possition Mapp

            config.CreateMap<Possition, PossitionDto>()
                .ForMember(p => p.Sliders,
                    p => p.MapFrom(q => q.Sliders))
                .ForMember(p => p.Banners,
                    p => p.MapFrom(q => q.Banners));

            config.CreateMap<PossitionDto, Possition>()
                .ForMember(p => p.Sliders,
                    p => p.MapFrom(q => q.Sliders))
                .ForMember(p => p.Banners,
                    p => p.MapFrom(q => q.Banners));
            config.CreateMap<Possition, CreatePossitionDto>().ReverseMap();
            config.CreateMap<Possition, UpdatePossitionDto>().ReverseMap();

            #endregion

            #region Menu Mapp

            config.CreateMap<MenuItemDto, MenuItem>()
                .ForMember(p => p.SubMenus,
                    p => p.MapFrom(q => q.SubMenus));
            config.CreateMap<MenuItem, MenuItemDto>()
                .ForMember(p => p.SubMenus,
                    p => p.MapFrom(q => q.SubMenus));
            config.CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
            config.CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap();
            //
            config.CreateMap<SubMenu, SubMenuDto>()
                .ForMember(p => p.Category,
                    p => p.MapFrom(q => q.Category))
                .ForMember(p => p.MenuItem,
                    p => p.MapFrom(q => q.MenuItem));
            config.CreateMap<SubMenuDto, SubMenu>()
                .ForMember(p => p.Category,
                    p => p.MapFrom(q => q.Category))
                .ForMember(p => p.MenuItem,
                    p => p.MapFrom(q => q.MenuItem));
            config.CreateMap<SubMenu, CreateSubMenuDto>().ReverseMap();
            config.CreateMap<SubMenu, UpdateSubMenuDto>().ReverseMap();
            #endregion

            #region Cart Mapp

            config.CreateMap<Cart, CartDto>()
                .ForMember(p => p.ApplicationUser,
                    p => p.MapFrom(q => q.ApplicationUser))
                .ForMember(p => p.CartItems,
                    p => p.MapFrom(q => q.CartItems));
            config.CreateMap<CartDto, Cart>()
                .ForMember(p => p.ApplicationUser,
                    p => p.MapFrom(q => q.ApplicationUser))
                .ForMember(p => p.CartItems,
                    p => p.MapFrom(q => q.CartItems));
            config.CreateMap<CreateCartDto, Cart>().ReverseMap();
            config.CreateMap<UpdateCartDto, Cart>().ReverseMap();

            #endregion

            #region CartItem Mapp

            config.CreateMap<CartItem, CartItemDto>()
                .ForMember(p => p.Cart,
                    p => p.MapFrom(q => q.Cart))
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product));

            config.CreateMap<CartItemDto, CartItem>()
                .ForMember(p => p.Cart,
                    p => p.MapFrom(q => q.Cart))
                .ForMember(p => p.Product,
                    p => p.MapFrom(q => q.Product));
            config.CreateMap<CreateCartItemDto, CartItem>().ReverseMap();
            config.CreateMap<UpdateCartItemDto, CartItem>().ReverseMap();

            #endregion
        });
        return mappingConfig;
    }
}