using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;

namespace Ayda.Ecommerce.Domains.Ecommerce;

public class ProductAttribute:BaseEntity<int>
{
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    public int AttributeId { get; set; }
    [ForeignKey("AttributeId")]
    public virtual CategoryAttribute CategoryAttribute { get; set; }
    public string AttributeValue { get; set; }
}