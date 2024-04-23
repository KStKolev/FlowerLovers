namespace FlowerLovers.Core.Services.ArticleServices.Models
{
    public class ArticleModel
    {
        public ArticleModel(
            int id,
            string title, 
            string publisherName, 
            string userImageUrl, 
            string articleImageUrl, 
            string content) 
        {
            Id = id;
            Title = title;
            PublisherName = publisherName;
            UserImageUrl = userImageUrl;
            ArticleImageUrl = articleImageUrl;
            Content = content;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
        public string UserImageUrl { get; set; } = string.Empty;
        public string ArticleImageUrl { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; 
    }
}
