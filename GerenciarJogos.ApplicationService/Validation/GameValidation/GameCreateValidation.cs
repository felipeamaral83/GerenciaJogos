using FluentValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;

namespace GerenciaJogos.ApplicationService.Validation.GameValidation
{
    public class GameCreateValidation : BaseValidation<Game>
    {
        private readonly IGameUnitOfWork _uow;
        
        public GameCreateValidation(IGameUnitOfWork uow)
        {
            _uow = uow;
            
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(RequiredField("Nome"))
                .MaximumLength(100).WithMessage(InvalidSizeField("Nome", 100))
                .Must(name =>
                {
                    return _uow.GameRepository.GetByName(name) == null;
                }).WithMessage(x => $"Jogo {x.Name} já cadastrado.");
        }
    }
}
