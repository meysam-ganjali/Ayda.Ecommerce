using Ayda.Ecommerce.App.Contract.IRepository;

namespace Ayda.Ecommerce.App;

public interface IUnitOfWork : IDisposable {
    ICategoryRepository CategoryService { get; }
    IAuthenticationRepository AuthService { get; }
    IUserRepository UserService { get; }
    IRoleRepository RoleService { get; }
    IProductRepository ProductService { get; }
    ISliderRepository SliderService { get; }
    IPossitionRepository PossitionService { get; }
    IBannerRepository BannerService { get; }
    IMenuRepository MenuService { get; }
}