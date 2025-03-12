using System.Net;

namespace LibrarySofttek.Exceptions
{
    public abstract class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        protected BaseException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message)
            : base(message, HttpStatusCode.NotFound) { }
    }

    public class BusinessException : BaseException
    {
        public BusinessException(string message)
            : base(message, HttpStatusCode.BadRequest) { }
    }

    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(string message)
            : base(message, HttpStatusCode.Unauthorized) { }
    }
}
