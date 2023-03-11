using System.ComponentModel.DataAnnotations;

namespace Ayda.Ecommerce.Domains.Finances;

public enum OrderState {
    [Display(Name = "در حالی پردازش")]
    Processing = 0,
    [Display(Name = "لغو شده")]
    Canceled = 1,
    [Display(Name = "تحویل شده")]
    Delivered = 2,
}