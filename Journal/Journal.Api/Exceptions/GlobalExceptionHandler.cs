using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Journal.Api.Exceptions
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void HandleCore(ExceptionHandlerContext context)
        {
            context.Result = new GlobalException()
            {
                StatusCode = HttpStatusCode.NotAcceptable,
                Message = context.Exception.Message,
                Request = context.Request
            };
        }
    }

    public class GlobalException : IHttpActionResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpRequestMessage Request { get; set; }

        public string Message { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(StatusCode)
            {
                Content = new StringContent(Message),
                RequestMessage = Request
            };

            return Task.FromResult(response);
        }
    }
}