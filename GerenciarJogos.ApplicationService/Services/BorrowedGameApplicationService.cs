using FluentValidation.Results;
using GerenciaJogos.ApplicationService.Dtos.BorrowedGame;
using GerenciaJogos.ApplicationService.Validation.BorrowedGameValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using System;
using System.Threading.Tasks;

namespace GerenciaJogos.ApplicationService.Services
{
    public class BorrowedGameApplicationService
    {
        private readonly IBorrowedGameUnitOfWork _uow;
        private readonly BorrowedGameValidation _borrowedGameValidation;
        private readonly AccountApplicationService _accountApplicationService;
        private readonly GameApplicationService _gameApplicationService;

        public BorrowedGameApplicationService(
            IBorrowedGameUnitOfWork uow,
            BorrowedGameValidation borrowedGameValidation,
            AccountApplicationService accountApplicationService,
            GameApplicationService gameApplicationService)
        {
            _uow = uow;
            _borrowedGameValidation = borrowedGameValidation;
            _accountApplicationService = accountApplicationService;
            _gameApplicationService = gameApplicationService;
        }

        public async Task<ValidationResult> Lend(BorrowedGamePostDto dto, string username)
        {
            var user = _accountApplicationService.GetByUsername(username);
            var borrowedGame = LendMapper(dto, user.Id);
            var validationResult = await _borrowedGameValidation.LendValidation.ValidateAsync(borrowedGame);

            if (!validationResult.IsValid)
                return validationResult;

            using var transaction = _uow.Database.BeginTransaction();
            _uow.BorrowedGameRepository.Add(borrowedGame);
            await _uow.CommitAsync();
            await _gameApplicationService.UpdateBorrowed(dto.IdGame, true);
            await transaction.CommitAsync();
            return validationResult;
        }

        public async Task<ValidationResult> GiveBack(Guid id)
        {
            var borrowedGame = await _uow.BorrowedGameRepository.GetByIdAsync(id);
            var validationResult = await _borrowedGameValidation.GiveBackValidation.ValidateAsync(borrowedGame);

            if (!validationResult.IsValid)
                return validationResult;

            using var transaction = _uow.Database.BeginTransaction();
            _uow.BorrowedGameRepository.Delete(borrowedGame);
            await _uow.CommitAsync();
            await _gameApplicationService.UpdateBorrowed(borrowedGame.IdGame, false);
            await transaction.CommitAsync();
            return validationResult;
        }

        /* O mapeamento entre entidade e DTO pode ser automatizado por bibliotecas como AutoMapper,
         * porém, já ouvi várias opiniões positivas e negativas sobre o uso do AutoMapper. */
        private BorrowedGame LendMapper(BorrowedGamePostDto dto, Guid idUser)
        {
            var borrowedGame = new BorrowedGame
            {
                IdUser = idUser,
                IdGame = dto.IdGame,
                IdFriend = dto.IdFriend
            };

            return borrowedGame;
        }
    }
}
