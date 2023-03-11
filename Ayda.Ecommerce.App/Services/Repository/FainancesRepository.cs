using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Finances;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Ordering;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class FainancesRepository : IFainancesRepository {
    private readonly DataBaseContext _db;
    private IMapper _mapper;

    public FainancesRepository(DataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<RequestPayDto>> AddRequestPayAsync(CreateRequestPayDto requestPayDto) {
        var user = await _db.ApplicationUsers.FindAsync(requestPayDto.UserId);

        RequestPay requestPay = new RequestPay() {
            Amount = requestPayDto.Amount,
            Guid = Guid.NewGuid(),
            IsPay = false,
            User = user,
            CreatedDate = DateTime.Now,
            Authority = "",
            IsShow = true,
            RefId = 0,
        };
        await _db.RequestPays.AddAsync(requestPay);
        await _db.SaveChangesAsync();

        return new ResultDto<RequestPayDto>() {
            Data = new RequestPayDto() {
                Guid = requestPay.Guid,
                Amount = requestPay.Amount,
                Email = user.Email,
                Id = requestPay.Id,
            },
            IsSuccess = true,
        };
    }
    public async Task<ResultDto<RequestPayDto>> GetRequestPayAsync(Guid guid) {
        var requestPay = await _db.RequestPays
            .Include(x => x.User)
            .FirstOrDefaultAsync(p => p.Guid == guid);

        if (requestPay != null) {
            return new ResultDto<RequestPayDto>() {
                Data = new RequestPayDto() {
                    Amount = requestPay.Amount,
                    Id = requestPay.Id,
                }
            };
        } else {
            return new ResultDto<RequestPayDto>() {
                IsSuccess = false,
                Message = "درخواست پرداخت یافت نشد"
            };
        }
    }

    public async Task<ResultDto<IEnumerable<RequestPayDto>>> GetRequestPayAsync() {
        throw new NotImplementedException();
    }

    public async Task<ResultDto> UpdateRequestPayAsync(UpdateRequestPayDto requestPay) {
        throw new NotImplementedException();
    }

    public async Task<ResultDto> CreateOrderAsync(CreateOrderDto orderDto) {
        var user = await _db.ApplicationUsers.FindAsync(orderDto.UserId);
        var requestPay = await _db.RequestPays.FindAsync(orderDto.RequestPayId);

        var cart = await _db.Carts
            .Include(p => p.CartItems)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(p => p.Id == orderDto.CartId);

        requestPay.IsPay = true;
        requestPay.Authority = orderDto.Authority;
        requestPay.RefId = orderDto.RefId;
        requestPay.PayDate = DateTime.Now;

        cart.Finished = true;

        Order order = new Order() {
            Address = orderDto.Address,
            PostalCode = orderDto.PostalCode,
            OrderState = OrderState.Processing,
            RequestPay = requestPay,
            User = user,
            CreatedDate = DateTime.Now,
            IsShow = true

        };
        await _db.Orders.AddAsync(order);

        List<OrderDetail> orderDetails = new List<OrderDetail>();
        foreach (var item in cart.CartItems) {

            OrderDetail orderDetail = new OrderDetail() {
                Count = item.Count,
                Order = order,
                Price = item.Product.Price,
                Product = item.Product,
                CreatedDate = DateTime.Now,
                IsShow = true,
            };
            orderDetails.Add(orderDetail);
        }


        await _db.OrderDetails.AddRangeAsync(orderDetails);
        await _db.SaveChangesAsync();

        return new ResultDto() {
            IsSuccess = true,
            Message = $"فاکتور با شماره {order.Id} برای شما صادر گردید",
        };
    }

    public async Task<ResultDto<IEnumerable<OrderDto>>> GetUserOrderAsync(long userId) {
        throw new NotImplementedException();
    }

    public async Task<ResultDto<IEnumerable<OrderDto>>> GetUserOrderAsync(OrderStateEnumDto orderState)
    {
        var oderState = _mapper.Map<OrderState>(orderState);
        var orders =  _db.Orders
            .Include(p => p.OrderDetails)
            .Where(p => p.OrderState == oderState)
            .OrderByDescending(p => p.Id)
            .ToList()
            .Select(p => new OrderDto {
                CreatedDate = p.CreatedDate,
                Id = p.Id,
                OrderState = _mapper.Map<OrderStateEnumDto>(p.OrderState),
                RequestPayId = p.RequestPayId,
                UserId = p.UserId,
                Address = p.Address,
                PostalCode = p.PostalCode,
                IsShow = p.IsShow,
                OrderDetails =p.OrderDetails.Select(q => new OrderDetailDto
                {
                    Count = q.Count,
                    Id = q.Id,
                    Price = q.Price,
                    ProductId = q.ProductId,
                }).ToList()
            }).ToList();

        return new ResultDto<IEnumerable<OrderDto>>() {
            Data =  orders,
            IsSuccess = true,
        };
    }
}