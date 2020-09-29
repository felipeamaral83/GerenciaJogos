using FluentValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using System.Linq;

namespace GerenciaJogos.ApplicationService.Validation.FriendValidation
{
    public class FriendDeleteValidation : BaseValidation<Friend>
    {
        private readonly IBorrowedGameUnitOfWork _borrowedGameUnitOfWork;

        public FriendDeleteValidation(IBorrowedGameUnitOfWork borrowedGameUnitOfWork)
        {
            _borrowedGameUnitOfWork = borrowedGameUnitOfWork;

            RuleFor(x => x.Id).Must(id =>
            {
                return !_borrowedGameUnitOfWork.BorrowedGameRepository
                    .GetAllReadOnly()
                    .Where(x => x.IdFriend == id)
                    .ToList()
                    .Any();
            }).WithMessage(x => $"Não é possível excluir o amigo {x.Name}, existem jogos emprestados a ele.");
        }
    }
}
