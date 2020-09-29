using FluentValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;

namespace GerenciaJogos.ApplicationService.Validation.AccountValidation
{
    public class AccountCreateValidation : BaseValidation<User>
    {
        private readonly IUserUnitOfWork _uow;

        public AccountCreateValidation(IUserUnitOfWork uow)
        {
            _uow = uow;
            
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(RequiredField("Usuário"))
                .MaximumLength(50).WithMessage(InvalidSizeField("Usuário", 50))
                .Must(username =>
                {
                    return _uow.UserRepository.GetByUsername(username) == null;
                }).WithMessage(x => $"Usuário {x.Username} já cadastrado.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(RequiredField("Senha"))
                .MaximumLength(250).WithMessage(InvalidSizeField("Senha", 250));

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage(RequiredField("Função"))
                .MaximumLength(50).WithMessage(InvalidSizeField("Função", 50));
        }
    }
}
