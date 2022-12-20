using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    { 
        protected IConfiguration Configuration { get; set; }


        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<HomeVideo> HomeVideo { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSlider> ProductSliders { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<SiteIdentity> SiteIdentity { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<SystemAdmin> SystemAdmin { get; set; }
        public virtual DbSet<TablesLog> TablesLogs { get; set; }
        public virtual DbSet<UserLog> UserLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            //optionsBuilder.UseQueryTrackingBehavior(queryTrackingBehavior:QueryTrackingBehavior.NoTracking);
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Server=(localdb)\\MSSQLLocalDB;Database=AdminPanelCoreDb; Trusted_Connection=True;")));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExtendedUser>(a =>
            {
                a.ToTable("Users");
                a.Property(p => p.Id).HasColumnName("UserId");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.Property(p => p.CreationTime).HasColumnName("CreationTime");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.Job).HasColumnName("Job");
                a.Property(p => p.Phone).HasColumnName("Phone");

                a.HasMany(p => p.AboutUs);
                a.HasMany(p => p.RefreshTokens);
                a.HasMany(p => p.UserOperationClaims);
                a.HasMany(p => p.Blog);
                a.HasMany(p => p.Categories);
                a.HasMany(p => p.Contact);
                a.HasMany(p => p.HomeVideo);
                a.HasMany(p => p.Products);
                a.HasMany(p => p.Services);
                a.HasMany(p => p.SiteIdentity);
                a.HasMany(p => p.Sliders);
                a.HasMany(p => p.TablesLogs);
                a.HasMany(p => p.UserLogs);
            });


            modelBuilder.Entity<AboutUs>(a =>
            {
                a.ToTable("AboutUs").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("AboutId");
                a.Property(p => p.Description).HasColumnName("Description");
                a.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                a.Property(p => p.State).HasColumnName("State)");

                a.HasOne(x => x.User);
            });

            modelBuilder.Entity<Blog>(b =>
            {
                b.ToTable("Blogs").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("BlogId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.CategoryId).HasColumnName("CategoryId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.SubCategoryId).HasColumnName("SubCategoryId");
                b.Property(p => p.Title).HasColumnName("Title");
                b.Property(p => p.Content).HasColumnName("Content");
                b.Property(p => p.Keywords).HasColumnName("Keywords");
                b.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
                b.Property(p => p.State).HasColumnName("State");
                b.HasOne(p => p.Categories);
                b.HasOne(p => p.SubCategories);
                b.HasOne(p => p.User);
                b.HasMany(p => p.Comments);
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.ToTable("Categories").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("CategoryId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.CategoryName).HasColumnName("CategoryName");
                b.Property(p => p.Description).HasColumnName("Description");
                b.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
                b.Property(p => p.State).HasColumnName("State");
                b.HasOne(p => p.User);
                b.HasMany(p => p.Blogs);
                b.HasMany(p => p.Products);
                b.HasMany(p => p.SubCategories);
            });

            modelBuilder.Entity<Comment>(b =>
            {
                b.ToTable("Comments").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("CommentId");
                b.Property(p => p.BlogId).HasColumnName("BlogId");
                b.Property(p => p.ProductId).HasColumnName("ProductId");
                b.Property(p => p.FirstLastName).HasColumnName("FirstLastName");
                b.Property(p => p.Email).HasColumnName("Email");
                b.Property(p => p.CommentContent).HasColumnName("CommentContent");
                b.Property(p => p.Confirmation).HasColumnName("Confirmation");
                b.HasOne(p => p.Blogs);
                b.HasOne(p => p.Products);
            });

            modelBuilder.Entity<Contact>(b =>
            {
                b.ToTable("Contact").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("ContactId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.Adress).HasColumnName("Adress");
                b.Property(p => p.Tel).HasColumnName("Tel");
                b.Property(p => p.Email).HasColumnName("Email");
                b.Property(p => p.EmailPassword).HasColumnName("EmailPassword");
                b.Property(p => p.Whatsapp).HasColumnName("Whatsapp");
                b.Property(p => p.Facebook).HasColumnName("Facebook");
                b.Property(p => p.Twitter).HasColumnName("Twitter");
                b.Property(p => p.Instagram).HasColumnName("Instagram");
                b.HasOne(p => p.User);
            });

            modelBuilder.Entity<HomeVideo>(b =>
            {
                b.ToTable("HomeVideo").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("HomeVideoId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.Title).HasColumnName("Title");
                b.Property(p => p.Description).HasColumnName("Description");
                b.Property(p => p.VideoUrl).HasColumnName("VideoUrl");
                b.HasOne(p => p.User);
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.ToTable("Products").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("ProductId");
                b.Property(p => p.CategoryId).HasColumnName("CategoryId");
                b.Property(p => p.SubCategoryId).HasColumnName("SubCategoryId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.Title).HasColumnName("Title");
                b.Property(p => p.Price).HasColumnName("Price");
                b.Property(p => p.OldPrice).HasColumnName("OldPrice");
                b.Property(p => p.Stock).HasColumnName("Stock");
                b.Property(p => p.Color).HasColumnName("Color");
                b.Property(p => p.File).HasColumnName("File");
                b.Property(p => p.Content).HasColumnName("Content");
                b.Property(p => p.UpdateDate).HasColumnName("UpdateDate");
                b.Property(p => p.Keywords).HasColumnName("Keywords");
                b.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
                b.Property(p => p.State).HasColumnName("State");
                b.HasOne(p => p.User);
                b.HasOne(p => p.Categories);
                b.HasOne(p => p.SubCategories);
                b.HasMany(p => p.Comments);
                b.HasMany(p => p.ProductSliders);

            });

            modelBuilder.Entity<ProductSlider>(b =>
            {
                b.ToTable("ProductSliders").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("ProductSliderId");
                b.Property(p => p.ProductId).HasColumnName("ProductId");
                b.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
                b.Property(p => p.State).HasColumnName("State");
                b.HasOne(p => p.Product);
            });


            modelBuilder.Entity<Service>(b =>
            {
                b.ToTable("Services").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("ServiceId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.Title).HasColumnName("Title");
                b.Property(p => p.Keywords).HasColumnName("Keywords");
                b.Property(p => p.Description).HasColumnName("Description");
                b.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
                b.Property(p => p.State).HasColumnName("State");
                b.HasOne(p => p.User);
            });

            modelBuilder.Entity<SiteIdentity>(b =>
            {
                b.ToTable("SiteIdentity").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("SiteIdentityId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.Title).HasColumnName("Title");
                b.Property(p => p.Keywords).HasColumnName("Keywords");
                b.Property(p => p.Description).HasColumnName("Description");
                b.Property(p => p.LogoUrl).HasColumnName("LogoUrl");
                b.Property(p => p.State).HasColumnName("State");
                b.HasOne(p => p.User);
            });

            modelBuilder.Entity<Slider>(b =>
            {
                b.ToTable("Sliders").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("SliderId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.Title).HasColumnName("Title");
                b.Property(p => p.Description).HasColumnName("Description");
                b.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
                b.Property(p => p.State).HasColumnName("State");
                b.HasOne(p => p.User);
            });

            modelBuilder.Entity<SubCategory>(b =>
            {
                b.ToTable("SubCategories").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("SubCategoryId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.EmendatorAdminId).HasColumnName("EmendatorAdminId");
                b.Property(p => p.CategoryId).HasColumnName("CategoryId");
                b.Property(p => p.SubCategoryName).HasColumnName("SubCategoryName");
                b.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
                b.Property(p => p.State).HasColumnName("State");
                b.HasOne(p => p.User);
                b.HasOne(p => p.Categories);
                b.HasMany(p => p.Products);
                b.HasMany(p => p.Blogs);
            });

            modelBuilder.Entity<SystemAdmin>(b =>
            {
                b.ToTable("SystemAdmin").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Email).HasColumnName("Email");
                b.Property(p => p.Password).HasColumnName("Password");
            });

            modelBuilder.Entity<TablesLog>(b =>
            {
                b.ToTable("TablesLogs").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("TablesLogId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.ItemId).HasColumnName("ItemId");
                b.Property(p => p.TableName).HasColumnName("TableName");
                b.Property(p => p.ItemName).HasColumnName("ItemName");
                b.Property(p => p.Process).HasColumnName("Process");
                b.HasOne(p => p.User);
            });

            modelBuilder.Entity<UserLog>(b =>
            {
                b.ToTable("UserLogs").HasKey(k => k.Id); ;
                b.Property(p => p.Id).HasColumnName("UserLogId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.State).HasColumnName("State");
                b.Property(p => p.LogDate).HasColumnName("LogDate");
                b.HasOne(p => p.User);
            });

            modelBuilder.Entity<OperationClaim>(b =>
            {
                b.ToTable("OperationClaims");
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.CreationTime).HasColumnName("CreationTime");
                b.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(b =>
            {
                b.ToTable("UserOperationClaims");
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.CreationTime).HasColumnName("CreationTime");
                b.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.HasOne(p => p.User);
                b.HasOne(p => p.OperationClaim);
            });

            modelBuilder.Entity<RefreshToken>(b =>
            {
                b.ToTable("RefreshTokens");
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Created).HasColumnName("Created");
                b.Property(p => p.Expires).HasColumnName("Expires");
                b.Property(p => p.Revoked).HasColumnName("Revoked");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.Token).HasColumnName("Token");
                b.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                b.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                b.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                b.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");

            });

        }
    }
 }
