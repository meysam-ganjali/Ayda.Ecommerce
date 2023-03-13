using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.Ordering;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IFainancesRepository
{
    Task<ResultDto<RequestPayDto>> AddRequestPayAsync(CreateRequestPayDto requestPayDto);
    Task<ResultDto<RequestPayDto>> GetRequestPayAsync(Guid guid);
    Task<ResultDto<IEnumerable<RequestPayDto>>> GetRequestPayAsync();
   
    //order
    Task<ResultDto> CreateOrderAsync(CreateOrderDto orderDto);
    ResultDto<GetForAdmin<OrderDto>> GetOrderForAdmin(OrderStateEnumDto state, int pageSize = 100, int pageNumber = 1);
    ResultDto<GetForAdmin<OrderDto>> GetOrderForUser(long UserId, int pageSize = 100, int pageNumber = 1);
    Task<ResultDto<OrderDto>> GetOrderDetail(long id);


}