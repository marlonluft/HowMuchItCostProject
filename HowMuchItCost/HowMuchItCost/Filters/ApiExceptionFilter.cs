using HowMuchItCost.API.ViewModel;
using HowMuchItCost.Library.CustomException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace HowMuchItCost.API.Filters
{
    /// <summary>
    /// https://weblog.west-wind.com/posts/2016/oct/16/error-handling-and-exceptionfilter-dependency-injection-for-aspnet-core-apis
    /// </summary>
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ApiErrorViewModel apiError = null;
            if (context.Exception is HowMuchItCostException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as HowMuchItCostException;
                context.Exception = null;
                apiError = new ApiErrorViewModel(ex.Message);

                context.HttpContext.Response.StatusCode = (int)ex.StatusCode;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiErrorViewModel("Unauthorized Access");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                // Unhandled errors
#if DEBUG
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#else
                var msg = "An unhandled error occurred.";
                string stack = null;
#endif

                apiError = new ApiErrorViewModel(msg)
                {
                    Detail = stack
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            // always return a JSON result
            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }
    }
}
