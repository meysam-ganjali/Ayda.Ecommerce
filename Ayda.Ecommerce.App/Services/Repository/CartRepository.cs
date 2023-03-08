using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;

namespace Ayda.Ecommerce.App.Services.Repository;

public class CartRepository:ICartRepository
{
    private readonly DataBaseContext _db;
    private IMapper _mapper;

    public CartRepository(DataBaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
}