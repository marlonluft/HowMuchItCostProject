using System;
using System.Runtime.Serialization;

namespace HowMuchItCost.Library.CustomException
{
    public class ExtractException : HowMuchItCostException
    {
        public ExtractException()
        {
        }

        public ExtractException(string message) : base(message)
        {
        }

        public ExtractException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExtractException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
