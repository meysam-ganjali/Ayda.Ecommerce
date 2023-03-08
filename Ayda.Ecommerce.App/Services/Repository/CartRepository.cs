using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Cart;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Carts;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class CartRepository : ICartRepository {
    private readonly DataBaseContext _db;
    private IMapper _mapper;

    public CartRepository(DataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto> AddToCart(int ProductId, Guid BrowserId) {
        var cart = await _db.Carts.FirstOrDefaultAsync(p => p.BrowserId == BrowserId && p.Finished == false);
        if (cart == null) {
            Cart newCart = new Cart() {
                Finished = false,
                BrowserId = BrowserId,
                TotalSum = 0,
                IsShow = true,
                CreatedDate = DateTime.Now,

            };
            await _db.Carts.AddAsync(newCart);
            await _db.SaveChangesAsync();
            cart = newCart;
        }


        var product = await _db.Products.FirstOrDefaultAsync(x=>x.Id == ProductId);

        var cartItem = await _db.CartItems.FirstOrDefaultAsync(p => p.ProductId == ProductId && p.CartId == cart.Id);
        if (cartItem != null) {
            cartItem.Count++;
        } else {
            CartItem newCartItem = new CartItem() {
                Cart = cart,
                Count = 1,
                Price = product.Price,
                Product = product,
                CreatedDate = DateTime.Now,

            };
            await _db.CartItems.AddAsync(newCartItem);
            await _db.SaveChangesAsync();
        }

        return new ResultDto() {
            IsSuccess = true,
            Message = $"محصول  {product.Name} با موفقیت به سبد خرید شما اضافه شد ",
        };
    }

    public async Task<ResultDto> AddToCart(int ProductId, Guid BrowserId, int count)
    {
        var cart = await _db.Carts.FirstOrDefaultAsync(p => p.BrowserId == BrowserId && p.Finished == false);
        if (cart == null)
        {
            Cart newCart = new Cart()
            {
                Finished = false,
                BrowserId = BrowserId,
                TotalSum = 0,
                IsShow = true,
                CreatedDate = DateTime.Now,
            };
            await _db.Carts.AddAsync(newCart);
            await _db.SaveChangesAsync();
            cart = newCart;
        }


        var product = await _db.Products.FindAsync(ProductId);

        var cartItem = await _db.CartItems.FirstOrDefaultAsync(p => p.ProductId == ProductId && p.CartId == cart.Id);
        if (cartItem != null)
        {
            cartItem.Count += count;
        }
        else
        {
            CartItem newCartItem = new CartItem()
            {
                Cart = cart,
                Count = count,
                Price = product.Price,
                Product = product,
                CreatedDate = DateTime.Now,

            };
            await _db.CartItems.AddAsync(newCartItem);
            await _db.SaveChangesAsync();
        }
        return new ResultDto() {
            IsSuccess = true,
            Message = $"محصول  {product.Name} با موفقیت به سبد خرید شما اضافه شد ",
        };
    }

    public async Task<ResultDto> RemoveFromCart(long ProductId, Guid BrowserId) {
            var cartitem = await _db.CartItems.FirstOrDefaultAsync(p => p.Cart.BrowserId == BrowserId);
            if (cartitem != null) {
                _db.CartItems.Remove(cartitem);
                await _db.SaveChangesAsync();
                return new ResultDto {
                    IsSuccess = true,
                    Message = "محصول از سبد خرید شما حذف شد"
                };

            } else {
                return new ResultDto {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }
        }

        public async Task<ResultDto<CartDto>> GetMyCart(Guid BrowserId, long? UserId) {
            try {
                var cart = await _db.Carts
                    .Include(p => p.CartItems)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.ProductImages)
                    .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                    .OrderByDescending(p => p.Id)
                    .FirstOrDefaultAsync();

                if (cart == null) {
                    return new ResultDto<CartDto>() {
                        Data = new CartDto() {
                            CartItems = new List<CartItemDto>(),

                        },
                    };
                }

                if (UserId != null) {
                    var user = await _db.ApplicationUsers.FindAsync(UserId);
                    cart.ApplicationUser = user;

                    await _db.SaveChangesAsync();
                }

                int sumAmount = 0;
                foreach (var item in cart.CartItems)
                {
                    sumAmount += (item.Count * item.Product.Price);
                }
                cart.TotalSum = sumAmount;
                await _db.SaveChangesAsync();
            return new ResultDto<CartDto>() {
                    Data = _mapper.Map<CartDto>(cart),
                    IsSuccess = true
                };
            } catch (Exception ex) {

                return new ResultDto<CartDto> {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<ResultDto> Add(long CartItemId) {
            var cartItem = await _db.CartItems.FindAsync(CartItemId);
            cartItem.Count++;
            await _db.SaveChangesAsync();
            return new ResultDto() {
                IsSuccess = true,
            };
        }

        public async Task<ResultDto> Add(long CartItemId, int count) {
            var cartItem = await _db.CartItems.FindAsync(CartItemId);
            cartItem.Count += count;
            await _db.SaveChangesAsync();
            return new ResultDto() {
                IsSuccess = true,
            };
        }

        public async Task<ResultDto> LowOff(long CartItemId) {
            var cartItem = await _db.CartItems.FindAsync(CartItemId);
            cartItem.Count--;
            if (cartItem.Count < 1) {
                _db.CartItems.Remove(cartItem);
            }
            await _db.SaveChangesAsync();
            return new ResultDto() {
                IsSuccess = true,
            };
        }
    }