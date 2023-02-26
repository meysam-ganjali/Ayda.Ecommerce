using Ayda.Ecommerce.ShareModels.Role;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Ayda.Ecommerce.ShareModels.User;

public class CreateApplicationUserDto
{
    public string FName { get; set; }
    public IFormFile? Image { get; set; }
    public string LName { get; set; }
    public string Password { get; set; }
    [Required(ErrorMessage = "تکرار کلمه عبور را وارد کنید")]
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
    public string OrganizationEmail { get; set; }
    public bool EmailConfirm { get; set; }
    public int RoleId { get; set; }
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