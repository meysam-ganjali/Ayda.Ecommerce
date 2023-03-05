using Ayda.Ecommerce.Domains.Base;

namespace Ayda.Ecommerce.Domains.Menu;

public class MenuItem : BaseEntity<int> {
    public string Name { get; set; }
    public virtual ICollection<SubMenu> SubMenus { get; set; }

}
