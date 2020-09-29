using FluentValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using System.Linq;

namespace GerenciaJogos.ApplicationService.Validation.BorrowedGameValidation
{
    public class BorrowedGameLendValidation : BaseValidation<BorrowedGame>
    {
        private readonly IGameUnitOfWork _gameUnitOfWork;
        private readonly IFriendUnitOfWork _friendUnitOfWork;

        public BorrowedGameLendValidation(
            IGameUnitOfWork gameUnitOfWork,
            IFriendUnitOfWork friendUnitOfWork)
        {
            _gameUnitOfWork = gameUnitOfWork;
            _friendUnitOfWork = friendUnitOfWork;

            RuleFor(x => x.IdGame).Must(idGame =>
            {
                return _gameUnitOfWork.GameRepository.GetById(idGame) != null;
            }).WithMessage("Jogo não encontrado.")
            .Must(idGame =>
            {
                return _gameUnitOfWork.GameRepository.GetAllReadOnly().Where(x => x.Id == idGame && x.Borrowed == true).FirstOrDefault() == null;
            }).WithMessage(x => $"O jogo " +
                $"{_gameUnitOfWork.GameRepository.GetById(x.IdGame).Name} já está emprestado para o amigo " +
                $"{_friendUnitOfWork.FriendRepository.GetById(x.IdFriend).Name}.");

            RuleFor(x => x.IdFriend).Must(idFriend =>
            {
                return _friendUnitOfWork.FriendRepository.GetById(idFriend) != null;
            }).WithMessage("Amigo não encontrado.");
        }
    }
}
