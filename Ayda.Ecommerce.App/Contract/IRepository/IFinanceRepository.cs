using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Finances;
using Ayda.Ecommerce.ShareModels.Finances.FeaturesInvoic;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IFinanceRepository
{
    Task<ResultDto<FeaturesInvoiceDto>> AddRequestPayAsync(CreateFeaturesInvoiceDto featureInvoice);
    Task<ResultDto<FeaturesInvoiceDto>> GetRequestPayAsync(Guid guid);
    ResultDto<GetForAdmin<FeaturesInvoiceDto>> GetRequestPaysAsync(bool? isPay, int pageSize = 100, int pageNumber = 1);
    Task<ResultDto> CreateOrderAsync(CreateInvoicDto orderDto);
    ResultDto<GetForAdmin<InvoicesDto>> GetOrders(OrderStateDto state, int pageSize = 100, int pageNumber = 1);
    ResultDto<GetForAdmin<InvoicesDto>> GetOrders(long userId, int pageSize = 100, int pageNumber = 1);
    Task<ResultDto<InvoicesDto>> GetOrder(long id);
    Task<ResultDto> ChangeToDelivere(long id);
    Task<ResultDto> CancleInvoice(long id);
}