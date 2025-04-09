namespace BlogiAPI.Domain.Services
{

    public class OperationResult
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }


        private OperationResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;

        }

        public static OperationResult Success(string message = "Operation Successful")
        {
            return new OperationResult(true, message);
        }

        public static OperationResult Error(string message)
        {
            return new OperationResult(false, message);
        }


    }
}
