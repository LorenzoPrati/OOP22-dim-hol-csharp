using System;

namespace Map
{
    /// <summary>
    /// Exception that is thrown when an error occurs during map loading.
    /// It is a subclass of the Exception class, indicating that it is a checked exception.
    /// </summary>
    public class MapLoadingException : Exception
    {
        public MapLoadingException(string message) : base(message)
        {
        }

        public MapLoadingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}