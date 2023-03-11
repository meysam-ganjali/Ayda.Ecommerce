using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.Ecommerce;

namespace Ayda.Ecommerce.Domains.Finances;

public class OrderDetail : BaseEntity<long> {
    public long OrderId { get; set; }
    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; }
   
   public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
 

    public int Price { get; set; }
    public int Count { get; set; }
}