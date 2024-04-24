namespace FlowerLovers.Core.Services.ArticleServices.Models
{
    public class DetailsArticleModel
    {
        public DetailsArticleModel(
            int id,
            string title, 
            string publisherName,
            int publisherId,
            string publisherImageUrl,
            string articleImageUrl,
            string content, 
            DateTime dateOfPublish,
            double averageRate)
        {
            Id = id;
            Title = title;
            PublisherName = publisherName;
            PublisherId = publisherId;
            PublisherImageUrl = publisherImageUrl;
            ArticleImageUrl = articleImageUrl;
            Content = content;
            DateOfPublish = dateOfPublish;
            AverageRate = averageRate;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
        public int PublisherId { get; set; }
        public string PublisherImageUrl { get; set; } = string.Empty;
        public string ArticleImageUrl { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DateOfPublish { get; set; }
        public double AverageRate { get; set; }
    }
}
