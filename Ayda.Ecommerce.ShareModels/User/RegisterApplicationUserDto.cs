using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Ayda.Ecommerce.ShareModels.User;

public class RegisterApplicationUserDto
{
    public string FName { get; set; }
    public string LName { get; set; }
    public string Password { get; set; }
    [Required(ErrorMessage = "تکرار کلمه عبور را وارد کنید")]
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
    public string? Avatar { get; set; }
    public string? UserPhone { get; set; }
    public IFormFile? Image { get; set; }
    public Gender Gender { get; set; }
}