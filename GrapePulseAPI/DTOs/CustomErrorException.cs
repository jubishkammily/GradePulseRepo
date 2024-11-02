namespace GradePulseAPI.DTOs
{
    public class CustomErrorException : Exception
    {
        public int StatusCode { get; }
        public CustomErrorException(string message, int statusCode)
        : base(message)
        {
            StatusCode = statusCode;
        }

    }
}
