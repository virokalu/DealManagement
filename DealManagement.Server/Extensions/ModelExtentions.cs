using FluentValidation;

namespace DealManagement.Server.Extensions
{
    public static class ModelExtensions
    {
        public static List<string> GetErrorMessages(this ValidationException exception)
        {
            return exception.Errors
                .Select(e => e.ErrorMessage)
                .ToList();
        }
        public static List<string> GetErrorMessages(string exception)
        {
            return exception
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToList();
        }
    }
}
