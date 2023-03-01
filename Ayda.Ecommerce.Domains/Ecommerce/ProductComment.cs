using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.User;

namespace Ayda.Ecommerce.Domains.Ecommerce;

public class ProductComment : BaseEntity<long>
{
    public string CommentText { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser ApplicationUser { get; set; }
}