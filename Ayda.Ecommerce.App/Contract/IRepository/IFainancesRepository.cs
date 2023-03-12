using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Ordering;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IFainancesRepository
{
    Task<ResultDto<RequestPayDto>> AddRequestPayAsync(CreateRequestPayDto requestPayDto);
    Task<ResultDto<RequestPayDto>> GetRequestPayAsync(Guid guid);
    Task<ResultDto<IEnumerable<RequestPayDto>>> GetRequestPayAsync();
   
    //order
    Task<ResultDto> CreateOrderAsync(CreateOrderDto orderDto);
    Task<ResultDto<IEnumerable<OrderDto>>> GetUserOrderAsync(long userId);
    Task<ResultDto<IEnumerable<OrderDto>>> GetUserOrderAsync(OrderStateEnumDto orderState);


}