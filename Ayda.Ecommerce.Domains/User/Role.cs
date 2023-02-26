using Ayda.Ecommerce.Domains.Base;

namespace Ayda.Ecommerce.Domains.User;

public class Role:BaseEntity<int>
{
    public string Name { get; set; }
    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
}