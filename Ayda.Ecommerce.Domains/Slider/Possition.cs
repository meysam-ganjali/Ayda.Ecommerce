using Ayda.Ecommerce.Domains.Base;

namespace Ayda.Ecommerce.Domains.Slider;

public class Possition : BaseEntity<int> {
    public string PossitionNameFA { get; set; }
    public string ProssitionNameEN { get; set; }
    public virtual ICollection<Slider> Sliders { get; set; }
    public virtual ICollection<Banner> Banners { get; set; }
}