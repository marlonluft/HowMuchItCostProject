using System;
using System.Runtime.Serialization;

namespace HowMuchItCost.Library.CustomException
{
    public class HowMuchItCostException : Exception
    {
        public HowMuchItCostException()
        {
        }

        public HowMuchItCostException(string message) : base(message)
        {
        }

        public HowMuchItCostException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HowMuchItCostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
