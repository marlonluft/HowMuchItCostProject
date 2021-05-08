using System;
using System.Net;
using System.Runtime.Serialization;

namespace HowMuchItCost.Library.CustomException
{
    public class ExtractException : HowMuchItCostException
    {
        public ExtractException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }

        public ExtractException(string message, Exception innerException) : base(message, innerException, HttpStatusCode.NotFound)
        {
        }

        protected ExtractException(SerializationInfo info, StreamingContext context) : base(info, context, HttpStatusCode.NotFound)
        {
        }
    }
}
