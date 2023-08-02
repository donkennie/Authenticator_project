using System.Net;

namespace Authenticator_project.Core
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }

        public static APIResponse GetFailureMessage(HttpStatusCode statusCode, object data, string msg)
        {
            var failedResponse = new APIResponse()
            {
                StatusCode = statusCode,
                Data = data,
                Message = msg,
                IsSuccess = false
            };

            return failedResponse;
        }

        public static APIResponse GetSuccessMessage(HttpStatusCode statusCode, object data, string msg)
        {
            var successResponse = new APIResponse()
            {
                StatusCode = statusCode,
                Data = data,
                Message = msg,
                IsSuccess = true
            };

            return successResponse;
        }
    }
}
