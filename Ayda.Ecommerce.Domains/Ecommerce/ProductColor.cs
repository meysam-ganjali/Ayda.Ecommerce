using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;

namespace Ayda.Ecommerce.Domains.Ecommerce;

public class ProductColor : BaseEntity<int>
{
    public string? ColorName { get; set; }
    public string ColorHex { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}