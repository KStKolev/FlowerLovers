namespace FlowerLovers.Core.CustomExceptions
{
    [Serializable]
    public class CategoryNullException : Exception
    {
        public CategoryNullException() { }

        public CategoryNullException(string message) : base(message) { }

        public CategoryNullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
