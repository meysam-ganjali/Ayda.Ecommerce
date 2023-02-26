using System.ComponentModel.DataAnnotations;

namespace Ayda.Ecommerce.ShareModels.User;

public class LoginDto
{
    [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
    [MinLength(6,ErrorMessage = "کلمه عبور حداقل باید 6 حرف داشته باشد")]
    public string Password { get; set; }
   
    [Required(ErrorMessage = "نام کاربری را وارد کنید")]
    public string UserName { get; set; }
    public bool IsRememberMe { get; set; }
}