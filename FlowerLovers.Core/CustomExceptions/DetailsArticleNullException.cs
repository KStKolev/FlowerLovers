namespace FlowerLovers.Core.CustomExceptions
{
    public class DetailsArticleNullException : Exception
    {
        public DetailsArticleNullException() { }

        public DetailsArticleNullException(string message) : base(message) { }

        public DetailsArticleNullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
