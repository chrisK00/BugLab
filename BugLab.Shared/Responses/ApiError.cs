namespace BugLab.Shared.Responses
{
    public class ApiError
    {
        public ApiError(string message, string stackTrace = null)
        {
            Message = message;
            StackTrace = stackTrace;
        }

        public string StackTrace { get; }
        public string Message { get; }
    }
}
