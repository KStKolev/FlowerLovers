namespace FlowerLovers.Core.CustomExceptions
{
    [Serializable]
    public class ImageNullException : Exception
    {
        public ImageNullException() { }

        public ImageNullException(string message) 
            : base(message) { }

        public ImageNullException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
