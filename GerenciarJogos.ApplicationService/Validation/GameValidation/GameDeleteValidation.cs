using FluentValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using System.Linq;

namespace GerenciaJogos.ApplicationService.Validation.GameValidation
{
    public class GameDeleteValidation : BaseValidation<Game>
    {
        private readonly IGameUnitOfWork _uow;

        public GameDeleteValidation(IGameUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Id).Must(id =>
            {
                return _uow.GameRepository.GetAllReadOnly().Where(x => x.Id == id && x.Borrowed == false).FirstOrDefault() != null;
                    
            }).WithMessage(x => $"Não é possível excluir o jogo {x.Name}, o mesmo se encontra emprestado.");
        }
    }
}
