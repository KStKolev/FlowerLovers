namespace FlowerLovers.Core.CustomExceptions
{
    [Serializable]
    public class UserAccountNullException : Exception
    {
        public UserAccountNullException() { }

        public UserAccountNullException(string message)
        : base(message) { }

        public UserAccountNullException(string message, Exception inner) 
        : base(message, inner) { }
    }
}
