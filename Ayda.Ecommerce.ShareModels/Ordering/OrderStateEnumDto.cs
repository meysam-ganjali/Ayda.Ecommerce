using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ayda.Ecommerce.ShareModels.Ordering;

public enum OrderStateEnumDto
{
    [Display(Name = "در حالی پردازش")]
    Processing = 0,
    [Display(Name = "لغو شده")]
    Canceled = 1,
    [Display(Name = "تحویل شده")]
    Delivered = 2,
}