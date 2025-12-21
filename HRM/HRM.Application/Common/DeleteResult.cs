namespace HRM.Application.Common
{
    public class DeleteResult
    {

        public bool IsSuccess { get; set; }

        public string? ErrorMessage { get; set; }

        public int StatusCode { get; set; }

        public static DeleteResult Success()
        {
            return new DeleteResult
            {
                IsSuccess = true,
                StatusCode = 200
            };
        }

        public static DeleteResult Failure(string errorMessage, int statusCode = 400)
        {
            return new DeleteResult
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
                StatusCode = statusCode
            };
        }
    }
}