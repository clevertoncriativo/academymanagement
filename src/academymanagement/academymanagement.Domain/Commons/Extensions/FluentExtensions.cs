using academymanagement.Domain.Messages.Responses;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace academymanagement.Domain.Commons.Extensions
{
    public static class FluentExtensions
    {
        public static IEnumerable<ResponseError> AsReponseErrors(this ValidationResult validationResult) => validationResult.Errors.Select(e => new ResponseError(e.PropertyName, e.ErrorMessage)).ToArray();
    }
}
