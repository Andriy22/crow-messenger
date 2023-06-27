using System.Net;

namespace Application.Common.Exceptions
{
    public class CustomHttpException : Exception
    {
        public readonly HttpStatusCode StatusCode;

        public CustomHttpException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
