using FlowerLovers.Data.Data.Models;

namespace FlowerLovers.Core.Services.ArticleServices.Models
{
    public class ArticleModel
    {
        public IEnumerable<Article> Articles { get; set; } = new List<Article>();
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
