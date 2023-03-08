using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Carts;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface ICartRepository
{
    Task<ResultDto> AddToCart(long ProductId, Guid BrowserId);
    Task<ResultDto> AddToCart(long ProductId, Guid BrowserId,int count);
    Task<ResultDto> RemoveFromCart(long ProductId, Guid BrowserId);
    Task<ResultDto<CartDto>> GetMyCart(Guid BrowserId, long? UserId);
    Task<ResultDto> Add(long CartItemId);
    Task<ResultDto> Add(long CartItemId,int count);
    Task<ResultDto> LowOff(long CartItemId);
}