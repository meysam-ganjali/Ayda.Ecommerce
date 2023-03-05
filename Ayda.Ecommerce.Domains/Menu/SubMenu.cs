using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.Ecommerce;

namespace Ayda.Ecommerce.Domains.Menu;

public class SubMenu : BaseEntity<int>
{
    public int MenuItemId { get; set; }
    [ForeignKey("MenuItemId")]
    public virtual MenuItem MenuItem { get; set; }

    public string Title { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
}