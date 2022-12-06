using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class ExtendedUser: User
{
    public ExtendedUser()
    {
  
        this.AboutUs = new HashSet<AboutUs>();
        this.Blogs = new HashSet<Blogs>();
        this.Categories = new HashSet<Category>();
        this.Contact = new HashSet<Contact>();
        this.HomeVideo = new HashSet<HomeVideo>();
        this.Products = new HashSet<Product>();
        this.Services = new HashSet<Service>();
        this.SiteIdentity = new HashSet<SiteIdentity>();
        this.Sliders = new HashSet<Slider>();
        this.SubCategories = new HashSet<SubCategory>();
        this.TablesLogs = new HashSet<TablesLog>();
        this.UserLogs = new HashSet<UserLog>();
    }
    public string Job { get; set; }
    public string Phone { get; set; }

    public virtual ICollection<AboutUs> AboutUs { get; set; }
    public virtual ICollection<Blogs> Blogs { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Contact> Contact { get; set; }
    public virtual ICollection<HomeVideo> HomeVideo { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<Service> Services { get; set; }
    public virtual ICollection<SiteIdentity> SiteIdentity { get; set; }
    public virtual ICollection<Slider> Sliders { get; set; }
    public virtual ICollection<SubCategory> SubCategories { get; set; }
    public virtual ICollection<TablesLog> TablesLogs { get; set; }
    public virtual ICollection<UserLog> UserLogs { get; set; }
}