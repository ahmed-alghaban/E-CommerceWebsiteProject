namespace E_CommerceWebsiteProject.MVC.Utilities.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException(IDictionary<string, string[]> errors) : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
}