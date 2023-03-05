using Ayda.Ecommerce.Domains.Base;

namespace Ayda.Ecommerce.Domains.Slider;

public class Banner : BaseEntity<int> {
    public string? Title { get; set; }
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public int PossitionId { get; set; }
    public virtual Possition Possition { get; set; }
}