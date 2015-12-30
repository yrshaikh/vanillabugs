using System;

namespace Service.Core
{
    public class AutoMappingException : Exception
    {
        public AutoMappingException()
        {

        }

        public AutoMappingException(string message)
            : base(message)
        {

        }

        public AutoMappingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
