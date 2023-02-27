using Ayda.Ecommerce.App.Contract.IRepository;

namespace Ayda.Ecommerce.App;

public interface IUnitOfWork : IDisposable {
    ICategoryRepository CategoryService { get; }
    IAuthenticationRepository AuthService { get; }
    IUserRepository UserService { get; }
    IRoleRepository RoleService { get; }
}