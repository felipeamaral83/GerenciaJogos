using FluentValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;

namespace GerenciaJogos.ApplicationService.Validation.GameValidation
{
    public class GameUpdateValidation : BaseValidation<Game>
    {
        private readonly IGameUnitOfWork _uow;

        public GameUpdateValidation(IGameUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(RequiredField("Nome"))
                .MaximumLength(100).WithMessage(InvalidSizeField("Nome", 100));

            RuleFor(x => x)
                .Must(game =>
                {
                    return _uow.GameRepository.GetByName(game.Name, game.Id) == null;
                }).WithMessage(x => $"Jogo {x.Name} já cadastrado.");
        }
    }
}
