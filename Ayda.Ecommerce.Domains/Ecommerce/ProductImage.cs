using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;

namespace Ayda.Ecommerce.Domains.Ecommerce;

public class ProductImage:BaseEntity<int>
{
    public string ImagePath { get; set; }
    public string? AltTagAttribute { get; set; }
    public string? TitleTagAttribute { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}