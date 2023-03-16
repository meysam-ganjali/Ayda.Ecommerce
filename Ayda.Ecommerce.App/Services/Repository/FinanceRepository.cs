using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.Domains.Finances;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Finances;
using Ayda.Ecommerce.ShareModels.Finances.FeaturesInvoic;
using Ayda.Ecommerce.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class FinanceRepository : IFinanceRepository {
    private readonly DataBaseContext _db;
    private IMapper _mapper;

    public FinanceRepository(DataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<FeaturesInvoiceDto>> AddRequestPayAsync(CreateFeaturesInvoiceDto featureInvoice) {
        var user = await _db.ApplicationUsers.FindAsync(featureInvoice.UserId);
        FeaturesInvoice payRequest = new FeaturesInvoice {
            User = user,
            Amount = featureInvoice.Amount,
            Guid = Guid.NewGuid(),
            IsPay = false,
            Authority = "Not Authority",
            CreatedDate = DateTime.Now,
            RefId = -1,
            PostalAddress = featureInvoice.PostalAddress,
            PostalCode = featureInvoice.PostalCode,
            InvoicePhone = featureInvoice.InvoicePhone,
            IsShow = true

        };
        if (featureInvoice.Amount < 1 || featureInvoice.Amount == null) {
            return new ResultDto<FeaturesInvoiceDto> {
                Data = null,
                IsSuccess = false,
                Message = "مبلغ درخواستی نا معتبر است"
            };
        }

        await _db.FeaturesInvoices.AddAsync(payRequest);
        try {
            await _db.SaveChangesAsync();
            return new ResultDto<FeaturesInvoiceDto> {
                Data = _mapper.Map<FeaturesInvoiceDto>(payRequest),
                IsSuccess = true,
                Message = "درخواست پرداخت ایجاد شد"
            };
        } catch (Exception e) {
            return new ResultDto<FeaturesInvoiceDto> {
                Data = null,
                IsSuccess = false,
                Message = e.Message
            };
        }

    }

    public async Task<ResultDto<FeaturesInvoiceDto>> GetRequestPayAsync(Guid guid) {
        var getFeatureInvoic = await _db.FeaturesInvoices
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Guid == guid);
        if (getFeatureInvoic == null) {
            return new ResultDto<FeaturesInvoiceDto> {
                Data = null,
                IsSuccess = false,
                Message = "درخواست یافت نشد"
            };
        }

        return new ResultDto<FeaturesInvoiceDto> {
            IsSuccess = true,
            Data = _mapper.Map<FeaturesInvoiceDto>(getFeatureInvoic)
        };
    }

    public ResultDto<GetForAdmin<FeaturesInvoiceDto>> GetRequestPaysAsync(bool? isPay, int pageSize = 100, int pageNumber = 1) {
        int rowCount = 0;
        List<FeaturesInvoice> featureInvoices;
        switch (isPay) {
            case true: {
                    featureInvoices = _db.FeaturesInvoices
                        .Include(x => x.User)
                        .Include(x => x.Invoices)
                        .Where(x => x.IsPay == true)
                        .ToPaged(pageNumber, pageSize, out rowCount).ToList();
                    break;
                }
            case false: {
                    featureInvoices = _db.FeaturesInvoices
                        .Include(x => x.User)
                        .Include(x => x.Invoices)
                        .Where(x => x.IsPay == false)
                        .ToPaged(pageNumber, pageSize, out rowCount).ToList();
                    break;
                }
            default: {
                    featureInvoices = _db.FeaturesInvoices
                        .Include(x => x.User)
                        .Include(x => x.Invoices)
                        .ToPaged(pageNumber, pageSize, out rowCount).ToList();
                    break;
                }
        }

        return new ResultDto<GetForAdmin<FeaturesInvoiceDto>> {
            Data = new GetForAdmin<FeaturesInvoiceDto>() {
                EntityDto = _mapper.Map<List<FeaturesInvoiceDto>>(featureInvoices),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = rowCount
            },
            IsSuccess = true
        };
    }

    public async Task<ResultDto> CreateOrderAsync(CreateInvoicDto orderDto) {
        var user = await _db.ApplicationUsers.FindAsync(orderDto.UserId);
        var requestPay = await _db.FeaturesInvoices.FindAsync(orderDto.FeaturesInvoiceId);

        var cart = await _db.Carts
            .Include(p => p.CartItems)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(p => p.Id == orderDto.CartId);

        requestPay.IsPay = true;
        requestPay.Authority = orderDto.Authority;
        requestPay.RefId = orderDto.RefId;
        requestPay.PayDate = DateTime.Now;

        cart.Finished = true;

        Invoice order = new Invoice() {
            OrderState = OrderState.Processing,
            FeaturesInvoice = requestPay,
            User = user,
            CreatedDate = DateTime.Now,
            IsShow = true

        };
        await _db.Invoices.AddAsync(order);

        List<InvoiceItem> orderDetails = new List<InvoiceItem>();
        foreach (var item in cart.CartItems) {

            InvoiceItem orderDetail = new InvoiceItem() {
                Count = item.Count,
                Invoice = order,
                Price = item.Price,
                Product = item.Product,
                CreatedDate = DateTime.Now,
                IsShow = true,
            };
            item.Product.Count -= item.Count;
            orderDetails.Add(orderDetail);
        }


        await _db.InvoiceItems.AddRangeAsync(orderDetails);
        await _db.SaveChangesAsync();

        return new ResultDto() {
            IsSuccess = true,
            Message = $"فاکتور با شماره {order.Id} برای شما صادر گردید",
        };
    }

    public ResultDto<GetForAdmin<InvoicesDto>> GetOrders(OrderStateDto state, int pageSize = 100, int pageNumber = 1) {
        int rowCount = 0;
        OrderState orderState = _mapper.Map<OrderState>(state);

        List<Invoice> invoices = _db.Invoices
            .Include(x => x.User)
            .Include(x => x.InvoiceItems)
            .ThenInclude(x => x.Product)
            .Include(x => x.FeaturesInvoice)
            .Where(x => x.OrderState == orderState)
            .ToPaged(pageNumber, pageSize, out rowCount).ToList();
        if (invoices.Count < 1) {
            return new ResultDto<GetForAdmin<InvoicesDto>> {
                Data = new GetForAdmin<InvoicesDto>() {
                    EntityDto = null,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    RowCount = rowCount
                },
                IsSuccess = false,
                Message = $"فاکتوری با  وضعیت {orderState} وجود ندارد"
            };
        }

        return new ResultDto<GetForAdmin<InvoicesDto>>() {
            Data = new GetForAdmin<InvoicesDto>() {
                EntityDto = _mapper.Map<List<InvoicesDto>>(invoices),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = rowCount
            },
            IsSuccess = true
        };
    }

    public ResultDto<GetForAdmin<InvoicesDto>> GetOrders(long userId, int pageSize = 100, int pageNumber = 1) {
        int rowCount = 0;

        List<Invoice> invoices = _db.Invoices
            .Include(x => x.User)
            .Include(x => x.InvoiceItems)
            .ThenInclude(x => x.Product)
            .Include(x => x.FeaturesInvoice)
            .Where(x => x.UserId == userId)
            .ToPaged(pageNumber, pageSize, out rowCount).ToList();
        if (invoices.Count < 1) {
            return new ResultDto<GetForAdmin<InvoicesDto>> {
                Data = new GetForAdmin<InvoicesDto>() {
                    EntityDto = null,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    RowCount = rowCount
                },
                IsSuccess = false,
                Message = $"فاکتوری یافت نشد"
            };
        }

        return new ResultDto<GetForAdmin<InvoicesDto>>() {
            Data = new GetForAdmin<InvoicesDto>() {
                EntityDto = _mapper.Map<List<InvoicesDto>>(invoices),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = rowCount
            },
            IsSuccess = true
        };
    }

    public async Task<ResultDto<InvoicesDto>> GetOrder(long id) {
        var order = await _db.Invoices
            .Include(x => x.User)
            .Include(x => x.InvoiceItems)
            .ThenInclude(x => x.Product)
            .Include(x => x.FeaturesInvoice)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (order == null) {
            return new ResultDto<InvoicesDto> {
                Data = null,
                IsSuccess = false,
                Message = "فاکتوری یافت نشد"
            };
        }

        return new ResultDto<InvoicesDto>() {
            Data = _mapper.Map<InvoicesDto>(order),
            IsSuccess = true
        };
    }

    public async Task<ResultDto> ChangeToDelivere(long id) {
        var order = await _db.Invoices
            .Include(x => x.User)
            .Include(x => x.InvoiceItems)
            .ThenInclude(x => x.Product)
            .Include(x => x.FeaturesInvoice)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (order == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "فاکتوری یافت نشد"
            };
        }

        order.OrderState = OrderState.Delivered;
        await _db.SaveChangesAsync();
        return new ResultDto() {
            IsSuccess = true,
            Message = "سفارش آماده ارسال می باشد"
        };
    }

    public async Task<ResultDto> CancleInvoice(long id) {
        throw new NotImplementedException();
    }
}