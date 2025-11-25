namespace CleanArcNetBackendBoilerplate.Application.Commons.OperationResult
{
    // Represents the result of an operation, encapsulating success status, returned data, and error messages.
    public class OperationResult<T>
    {
        public bool IsSuccess { get; private set; }
        public string? ErrorMessage { get; private set; }
        public List<string>? ErrorMessages { get; private set; }

        // Stores the data returned by the operation if it succeeded
        public T? Data { get; private set; }

        // Private constructor ensures instances can only be created via Success or Failure methods
        private OperationResult() { }

        // Creates a successful operation result with the given data
        public static OperationResult<T> Success(T value) => new OperationResult<T>
        {
            IsSuccess = true,
            Data = value,
            ErrorMessages = null,
            ErrorMessage = null
        };

        // Creates a successful operation result with the given data
        public static OperationResult<T> Failure(string errorMessage) => new OperationResult<T>
        {
            IsSuccess = false,
            ErrorMessage = errorMessage,
            ErrorMessages = new List<string> { errorMessage },
            Data = default
        };

        // Creates a failed operation result with multiple error messages
        public static OperationResult<T> Failure(List<string> errorMessages) => new OperationResult<T>
        {
            IsSuccess = false,
            ErrorMessages = errorMessages,
            ErrorMessage = string.Join(", ", errorMessages),
            Data = default
        };
    }
}
