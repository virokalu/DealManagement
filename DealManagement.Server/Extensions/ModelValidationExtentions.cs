using FluentValidation;

namespace DealManagement.Server.Extensions
{
    public static class ModelValidationExtensions
    {
        public static List<string> GetErrorMessages(this ValidationException exception)
        {
            return exception.Errors
                .Select(e => e.ErrorMessage)
                .ToList();
        }
    }
}
