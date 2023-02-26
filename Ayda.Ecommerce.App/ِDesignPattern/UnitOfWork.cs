using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.App.Services.Repository;
using Ayda.Ecommerce.Data.DataContext;
using Microsoft.AspNetCore.Hosting;

namespace Ayda.Ecommerce.App;

public class UnitOfWork : IUnitOfWork {
    private readonly DataBaseContext _db;
    private IHostingEnvironment _environment;
    private IMapper _mapper;

    public UnitOfWork(DataBaseContext db, IHostingEnvironment environment, IMapper mapper) {
        _db = db;
        _environment = environment;
        _mapper = mapper;
        CategoryService = new CategoryRepository(_db, _environment, _mapper);
        AuthService = new AuthenticationRepository(_db, _mapper, _environment);
    }
    public void Dispose() {
        _db.Dispose();
    }

    public ICategoryRepository CategoryService { get; }
    public IAuthenticationRepository AuthService { get; }
}