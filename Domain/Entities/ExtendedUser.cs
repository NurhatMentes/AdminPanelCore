using Core.Security.Entities;

namespace Domain.Entities;

public class ExtendedUser: User
{
    public ExtendedUser()
    {
  
        AboutUs = new HashSet<AboutUs>();
        Blogs = new HashSet<Blog>();
        Categories = new HashSet<Category>();
        Contact = new HashSet<Contact>();
        HomeVideo = new HashSet<HomeVideo>();
        Products = new HashSet<Product>();
        Services = new HashSet<Service>();
        SiteIdentity = new HashSet<SiteIdentity>();
        Sliders = new HashSet<Slider>();
        SubCategories = new HashSet<SubCategory>();
        TablesLogs = new HashSet<TablesLog>();
        UserLogs = new HashSet<UserLog>();
    }
    public string Job { get; set; }
    public string Phone { get; set; }

    public virtual ICollection<AboutUs> AboutUs { get; set; }
    public virtual ICollection<Blog> Blogs { get; set; }
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