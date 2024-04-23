namespace FlowerLovers.Core.CustomExceptions
{
    public class ArticleNullException : Exception
    {
        public ArticleNullException() { }
        public ArticleNullException(string message) : base(message) { }
        public ArticleNullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
