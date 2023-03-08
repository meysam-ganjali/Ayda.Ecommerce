using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.User;

namespace Ayda.Ecommerce.Domains.Cart;

public class Cart : BaseEntity<long> {
    public Guid BrowserId { get; set; }
    public bool Finished { get; set; }
    public int TotalSum { get; set; }
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
}