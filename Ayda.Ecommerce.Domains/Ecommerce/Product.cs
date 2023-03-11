using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.Cart;
using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Finances;

namespace Ayda.Ecommerce.Domains.Ecommerce;

public class Product:BaseEntity<int>
{

    public string Name { get; set; }
    public int Price { get; set; }
    public string? ImageCoverPath { get; set; }
    public string ShortDescription { get; set; }
    public string? FullDescription { get; set; }
    public int ShowCount { get; set; }
    public bool IsSotialProduct { get; set; }
    public bool IsDiscount { get; set; } = false;
    public string DiscountLableText { get; set; }
    public bool ShowOnHomepage { get; set; }
    public bool AllowCustomerComment { get; set; }
    public int Count { get; set; }
    public int Rate { get; set; }
    public int? Weight { get; set; }
    public int? Length { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    //Relation
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; }
    public virtual ICollection<ProductColor> ProductColors { get; set; }
    public virtual ICollection<ProductComment> ProductComments { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}