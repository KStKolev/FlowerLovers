namespace FlowerLovers.Core.CustomExceptions
{
    [Serializable]
    public class NameNullOrEmptyException : Exception
    {
        public NameNullOrEmptyException() { }

        public NameNullOrEmptyException(string message) : base(message) { }

        public NameNullOrEmptyException(string message, Exception inner) : base(message, inner) { }
    }
}
