using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;

namespace Ayda.Ecommerce.Domains.Ecommerce;

public class CategoryAttribute:BaseEntity<int>
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

}