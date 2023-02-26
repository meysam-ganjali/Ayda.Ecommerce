using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Role;

namespace Ayda.Ecommerce.ShareModels.User;

public class ApplicationUserDto : BaseDto<long>
{
    public string FName { get; set; }
    public string LName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string OrganizationEmail { get; set; }
    public bool EmailConfirm { get; set; }
    public int RoleId { get; set; }
    public RoleDto Role { get; set; }
    public string? Avatar { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LockoutEndDate { get; set; }
    public bool IsLocked { get; set; }
    public string? UserPhone { get; set; }
    public bool? PhoneConfirm { get; set; }
    public Gender Gender { get; set; }
    public DateTime? LastLoginDateTime { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

public enum Gender {
    WOMAN,
    MAN
}