using FluentValidation.Results;
using GerenciaJogos.ApplicationService.Dtos.Game;
using GerenciaJogos.ApplicationService.Validation.GameValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaJogos.ApplicationService.Services
{
    public class GameApplicationService
    {
        private readonly IGameUnitOfWork _uow;
        private readonly GameValidation _gameValidation;
        private readonly AccountApplicationService _accountApplicationService;

        public GameApplicationService(
            IGameUnitOfWork uow,
            GameValidation gameValidation,
            AccountApplicationService accountApplicationService)
        {
            _uow = uow;
            _gameValidation = gameValidation;
            _accountApplicationService = accountApplicationService;
        }

        public async Task<ValidationResult> Create(GamePostDto dto, string username)
        {
            var user = _accountApplicationService.GetByUsername(username);
            var game = CreateMapper(dto, user.Id);
            var validationResult = await _gameValidation.CreateValidation.ValidateAsync(game);

            if (!validationResult.IsValid)
                return validationResult;

            _uow.GameRepository.Add(game);
            await _uow.CommitAsync();
            return validationResult;
        }

        public async Task<ValidationResult> Update(GamePutDto dto)
        {
            var game = await _uow.GameRepository.GetByIdAsync(dto.Id);
            game = UpdateMapper(game, dto);
            var validationResult = await _gameValidation.UpdateValidation.ValidateAsync(game);

            if (!validationResult.IsValid)
                return validationResult;

            _uow.GameRepository.Edit(game);
            await _uow.CommitAsync();
            return validationResult;
        }

        public async Task UpdateBorrowed(Guid id, bool borrowed)
        {
            var game = await _uow.GameRepository.GetByIdAsync(id);
            game = UpdateBorrowedMapper(game, borrowed);
            _uow.GameRepository.Edit(game);
            await _uow.CommitAsync();
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var game = await _uow.GameRepository.GetByIdAsync(id);
            var validationResult = await _gameValidation.DeleteValidation.ValidateAsync(game);

            if (!validationResult.IsValid)
                return validationResult;

            _uow.GameRepository.Delete(game);
            await _uow.CommitAsync();
            return validationResult;
        }

        public List<GameListDto> GetAll(string username)
        {
            var user = _accountApplicationService.GetByUsername(username);
            var queryGame = _uow.GameRepository
                .GetAllReadOnly()
                .Where(x => x.IdUser == user.Id);
            
            var games = queryGame.Select(x => new GameListDto
            {
                Id = x.Id,
                Name = x.Name,
                Borrowed = x.Borrowed
            }).OrderBy(x => x.Name).ToList();

            return games;
        }

        public List<GameMyGamesDto> GetMyGames(string username)
        {
            var user = _accountApplicationService.GetByUsername(username);
            var queryGame = _uow.GameRepository
                .GetAllReadOnly()
                .Where(x => x.IdUser == user.Id);

            var myGames = queryGame.Select(x => new GameMyGamesDto
            {
                IdGame = x.Id,
                IdBorrowedGame = x.BorrowedGames.FirstOrDefault().Id,
                Game = x.Name,
                Friend = x.BorrowedGames.FirstOrDefault().Friend.Name,
                Borrowed = x.Borrowed ? "Sim" : "Não",
                LoanDate = x.BorrowedGames.FirstOrDefault().LoanDate
            }).OrderBy(x => x.Game).ToList();

            return myGames;
        }

        public List<GameGamesAvailableListDto> GetGamesAvailable(Guid idUser)
        {
            var queryGame = _uow.GameRepository
                .GetAllReadOnly()
                .Where(x => x.IdUser == idUser
                         && x.Borrowed == false);
            
            var games = queryGame.Select(x => new GameGamesAvailableListDto
            {
                Id = x.Id,
                Name = x.Name
            }).OrderBy(x => x.Name).ToList();

            return games;
        }

        /* O mapeamento entre entidade e DTO pode ser automatizado por bibliotecas como AutoMapper,
         * porém, já ouvi várias opiniões positivas e negativas sobre o uso do AutoMapper. */
        private Game CreateMapper(GamePostDto dto, Guid idUser)
        {
            var game = new Game
            {
                IdUser = idUser,
                Name = dto.Name
            };

            return game;
        }

        private Game UpdateMapper(Game game, GamePutDto dto)
        {
            game.Name = dto.Name;

            return game;
        }

        private Game UpdateBorrowedMapper(Game game, bool borrowed)
        {
            game.Borrowed = borrowed;
            return game;
        }
    }
}
