using academymanagement.Domain.Entities;
using FluentValidation;

namespace academymanagement.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            this.RuleFor(r => r.Name)
               .NotEmpty()
               .WithErrorCode("USER-001")
               .WithSeverity(Severity.Error)
               .WithMessage("O nome do é usuário é obrigatório.");


            this.RuleFor(r => r.UserGroupId)
               .NotEmpty()               
               .WithErrorCode("USER-002")
               .WithSeverity(Severity.Error)
               .WithMessage("O grupo de usuário é obrigatório.");
        }
    }
}
