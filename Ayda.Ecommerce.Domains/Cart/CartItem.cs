using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.Ecommerce;

namespace Ayda.Ecommerce.Domains.Cart;

public class CartItem : BaseEntity<long> {
    public int Count { get; set; }
    public int Price { get; set; }
    public long CartId { get; set; }
    [ForeignKey("CartId")] 
    public virtual Cart Cart { get; set; }

    public int  ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}