using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace academymanagement.Domain.Commons.Extensions
{
    public static class FluentExtensions
    {
        public static ICollection<KeyValuePair<string, string>> AsErrorProperties(this ValidationResult validationResult) => validationResult.Errors.Select(e => new KeyValuePair<string, string>(e.PropertyName, e.ErrorMessage)).ToArray();
    }
}
