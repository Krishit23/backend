namespace SavorySeasons.Backend.Api
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null, object details = null) : base(statusCode, message)
        {
            Data = details;
        }
    }
}
