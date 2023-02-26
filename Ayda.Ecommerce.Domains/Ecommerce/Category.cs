using Ayda.Ecommerce.Domains.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayda.Ecommerce.Domains.Ecommerce;

public class Category:BaseEntity<int>
{
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public string? Description { get; set; }
    public int? ParentCategoryId { get; set; }
    [ForeignKey("ParentCategoryId")]
    public virtual Category ParentCategory { get; set; }
    //برای نمایش زیر دسته های هر گروه
    public virtual ICollection<Category> SubCategories { get; set; }
    public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
}