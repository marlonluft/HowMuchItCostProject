using System;
using System.Net;
using System.Runtime.Serialization;

namespace HowMuchItCost.Library.CustomException
{
    public class HowMuchItCostException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HowMuchItCostException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HowMuchItCostException(string message, Exception innerException, HttpStatusCode statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        protected HowMuchItCostException(SerializationInfo info, StreamingContext context, HttpStatusCode statusCode) : base(info, context)
        {
            StatusCode = statusCode;
        }
    }
}
