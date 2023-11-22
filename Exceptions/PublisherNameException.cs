using System;

namespace _libreria_RLG.Exceptions
{
    public class PublisherNameException : Exception
    {
        public string PublisherName { get; private set; }

        public PublisherNameException()
        {

        }
        public PublisherNameException(string message) : base(message)
        {

        }
        public PublisherNameException(string message, Exception inner) : base(message, inner)
        {

        }
        public PublisherNameException(string message, string publisherName) : this(message)
        {
            PublisherName = publisherName;
        }
    }
}
