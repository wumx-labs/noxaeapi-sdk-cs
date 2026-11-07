using System;
using System.Net;

namespace WumxLabs.NoxAeApi.Exceptions
{
    public class NoxAeApiException : Exception
    {
        public HttpStatusCode? StatusCode { get; }
        public string? ResponseBody { get; }

        public NoxAeApiException(string message, HttpStatusCode? statusCode = null, string? responseBody = null, Exception? inner = null)
            : base(message, inner)
        {
            StatusCode = statusCode;
            ResponseBody = responseBody;
        }
    }

    public class AuthenticationException : NoxAeApiException
    {
        public AuthenticationException(string message, HttpStatusCode? statusCode = null, string? responseBody = null)
            : base(message, statusCode, responseBody) { }
    }

    public class NotFoundException : NoxAeApiException
    {
        public NotFoundException(string message, HttpStatusCode? statusCode = null, string? responseBody = null)
            : base(message, statusCode, responseBody) { }
    }
}
