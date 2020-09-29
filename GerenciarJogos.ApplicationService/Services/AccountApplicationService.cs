using FluentValidation.Results;
using GerenciaJogos.ApplicationService.Dtos.Account;
using GerenciaJogos.ApplicationService.Functions;
using GerenciaJogos.ApplicationService.Validation.AccountValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using GerenciarJogos.Infrastructure.Authorization.Services;
using System.Threading.Tasks;

namespace GerenciaJogos.ApplicationService.Services
{
    public class AccountApplicationService
    {
        private readonly IUserUnitOfWork _uow;
        private readonly AccountValidation _userValidation;

        public AccountApplicationService(
            IUserUnitOfWork uow,
            AccountValidation userValidation)
        {
            _uow = uow;
            _userValidation = userValidation;
        }

        public AccountUserGetDto Login(AccountLoginDto dto)
        {
            var accountUserGetDto = new AccountUserGetDto();
            var password = MD5Hash.Generate(dto.Password);
            var user = _uow.UserRepository.Get(dto.Username, password);

            if (user == null)
                return null;

            var token = TokenService.GenerateToken(user);

            accountUserGetDto.Id = user.Id;
            accountUserGetDto.Username = user.Username;
            accountUserGetDto.Role = user.Role;
            accountUserGetDto.Token = token;

            return accountUserGetDto;
        }

        public User GetByUsername(string username)
        {
            var user = _uow.UserRepository.GetByUsername(username);
            return user;
        }

        public async Task<ValidationResult> CreateUser(AccountUserPostDto dto)
        {
            var password = !string.IsNullOrWhiteSpace(dto.Password) ? MD5Hash.Generate(dto.Password) : null;
            var user = CreateUserMapper(dto, password);
            var validationResult = await _userValidation.CreateValidation.ValidateAsync(user);

            if (!validationResult.IsValid)
                return validationResult;

            _uow.UserRepository.Add(user);
            await _uow.CommitAsync();
            return validationResult;
        }

        /* O mapeamento entre entidade e DTO pode ser automatizado por bibliotecas como AutoMapper,
         * porém, já ouvi várias opiniões positivas e negativas sobre o uso do AutoMapper. */
        private User CreateUserMapper(AccountUserPostDto dto, string password)
        {
            var user = new User
            {
                Username = dto.Username,
                Password = password,
                Role = dto.Role
            };

            return user;
        }
    }
}
