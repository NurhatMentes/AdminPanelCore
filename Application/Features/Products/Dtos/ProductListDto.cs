using Domain.Entities;

namespace Application.Features.Products.Dtos
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public string EmendatorAdminName { get; set; }
        public string? SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        //public IList<string> ProductSliders { get; set; }
        //public IList<string> Comments { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public int? Stock { get; set; }
        public string Color { get; set; }
        public string File { get; set; }
        public string Content { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Keywords { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }

    }
}
