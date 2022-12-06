using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class Slider : Entity
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Slider()
    {
        this.State = true;
    }

    public int SliderId { get; set; }
    public Nullable<int> UserId { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ExtendedUser Users { get; set; }
}