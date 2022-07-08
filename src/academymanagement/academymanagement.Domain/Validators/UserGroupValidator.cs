using academymanagement.Domain.Entities;
using FluentValidation;

namespace academymanagement.Domain.Validators
{
    public class UserGroupValidator : AbstractValidator<UserGroup>
    {
        public UserGroupValidator()
        {
            this.RuleFor(r => r.Name)
               .NotEmpty()
               .WithErrorCode("USERGROUP-001")
               .WithSeverity(Severity.Error)
               .WithMessage("O nome do grupo de usuário é obrigatório.");
        }
    }
}
