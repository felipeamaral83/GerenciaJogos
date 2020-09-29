using FluentValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using System.Linq;

namespace GerenciaJogos.ApplicationService.Validation.BorrowedGameValidation
{
    public class BorrowedGameGiveBackValidation : BaseValidation<BorrowedGame>
    {
        private readonly IGameUnitOfWork _gameUnitOfWork;

        public BorrowedGameGiveBackValidation(IGameUnitOfWork gameUnitOfWork)
        {
            _gameUnitOfWork = gameUnitOfWork;
            
            RuleFor(x => x.IdGame).Must(idGame =>
            {
                return _gameUnitOfWork.GameRepository.GetAllReadOnly().Where(x => x.Id == idGame && x.Borrowed == false).FirstOrDefault() == null;
            }).WithMessage(x => $"O jogo {_gameUnitOfWork.GameRepository.GetById(x.IdGame).Name} já foi devolvido.");
        }
    }
}
