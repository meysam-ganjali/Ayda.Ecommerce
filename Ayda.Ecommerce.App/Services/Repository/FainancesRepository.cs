using System.Net.Sockets;
using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Finances;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.Ordering;
using Ayda.Ecommerce.ShareModels.User;
using Ayda.Ecommerce.Utilities;
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
            Authority = "-1",
            IsShow = true,
            RefId = 0,
        };
        user.Address = requestPayDto.Address;
        user.PostalCode = requestPayDto.PostalCode;
        await _db.RequestPays.AddAsync(requestPay);
        await _db.SaveChangesAsync();

        return new ResultDto<RequestPayDto>() {
            Data = new RequestPayDto() {
                Guid = requestPay.Guid,
                Amount = requestPay.Amount,
                Email = user.Email,
                Id = requestPay.Id,
                User = _mapper.Map<ApplicationUserDto>(user),
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
        var requestPay = await _db.RequestPays
            .Include(x => x.User)
            .ToListAsync();

        if (requestPay != null) {
            return new ResultDto<IEnumerable<RequestPayDto>>() {
                Data = _mapper.Map<IEnumerable<RequestPayDto>>(requestPay)
            };
        } else {
            return new ResultDto<IEnumerable<RequestPayDto>>() {
                IsSuccess = false,
                Message = "درخواست پرداخت یافت نشد"
            };
        }
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

    public ResultDto<GetForAdmin<OrderDto>> GetOrderForAdmin(OrderStateEnumDto state, int pageSize = 100, int pageNumber = 1) {
        int rowCount = 0;
        OrderState stateMapp = _mapper.Map<OrderState>(state);
        var orders = _db.Orders
            .Include(x => x.User)
            .Include(x => x.OrderDetails)
            .ThenInclude(x => x.Product)
            .Include(x => x.RequestPay)
            .Where(p=>p.OrderState == stateMapp)
            .ToPaged(pageNumber, pageSize, out rowCount).ToList();
     

        return new ResultDto<GetForAdmin<OrderDto>> {
            Data = new GetForAdmin<OrderDto>() {
                EntityDto = _mapper.Map<List<OrderDto>>(orders),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = rowCount
            },
            IsSuccess = true,
        };
    }

    public ResultDto<GetForAdmin<OrderDto>> GetOrderForUser(long UserId, int pageSize = 100, int pageNumber = 1) {
        int rowCount = 0;
        var orders = _db.Orders
            .Include(x => x.RequestPay)
                .Include(x => x.User)
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id)
            .ToPaged(pageNumber, pageSize, out rowCount).ToList();

        return new ResultDto<GetForAdmin<OrderDto>> {
            Data = new GetForAdmin<OrderDto>() {
                EntityDto = _mapper.Map<List<OrderDto>>(orders),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = rowCount
            },
            IsSuccess = true,
        };
    }

    public async Task<ResultDto<OrderDto>> GetOrderDetail(long id)
    {
        var order = await _db.Orders
            .Include(x => x.RequestPay)
            .Include(x => x.User)
            .Include(p => p.OrderDetails)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (order == null)
        {
            return new ResultDto<OrderDto>
            {
                Data = null,
                IsSuccess = false,
                Message = "فاکتور یافت نشد"
            };
        }

        return new ResultDto<OrderDto>
        {
            Data = new OrderDto
            {
                User = new ApplicationUserDto
                {
                    Address = order.User.Address,
                    FName=order.User.FName,
                    LName = order.User.LName
                },
                OrderDetails = order.OrderDetails.Select(p => new OrderDetailDto
                {
                    Count = p.Count,
                    Price = p.Price,
                    Product = new ProductDto
                    {
                        Name = p.Product.Name,
                        ImageCoverPath = p.Product.ImageCoverPath,
                    },
                }).ToList(),
                Amount = order.RequestPay.Amount,
                CreatedDate = order.CreatedDate,
                Id = order.Id,
                
            },
            IsSuccess = true
        };
    }


    
}