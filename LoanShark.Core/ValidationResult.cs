namespace LoanShark.Core
{
    public sealed class ValidationResult
    {
        public ValidationResult(string key, string message)
        {
            Key = key;
            Message = message;
        }
        public string Key { get; private set; }
        public string Message { get; private set; }
    }
}
