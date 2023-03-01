using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.Ecommerce;

namespace Ayda.Ecommerce.Domains.User;

public class ApplicationUser:BaseEntity<long>
{
    public string FName { get; set; }
    public string LName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string OrganizationEmail { get; set; }
    public bool EmailConfirm { get; set; }
    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; }
    public string? Avatar { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LockoutEndDate { get; set; }
    public bool IsLocked { get; set; }
    public string? UserPhone { get; set; }
    public bool? PhoneConfirm { get; set; }
    public Gender Gender { get; set; }
    public DateTime? LastLoginDateTime { get; set; }
    public virtual ICollection<ProductComment> ProductComments { get; set; }
}