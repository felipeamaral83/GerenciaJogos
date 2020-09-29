using GerenciaJogos.ApplicationService.Dtos.Account;
using GerenciaJogos.ApplicationService.Services;
using GerenciaJogos.ApplicationService.Validation.AccountValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using Moq;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GerenciaJogos.ApplicationService.Test.AccountTest
{
    public class AccountCreateUserTest
    {
        private readonly AccountApplicationService _app;
        private readonly AccountValidation _accountValidation;
        private readonly AccountCreateValidation _accountCreateValidation;
        private readonly Mock<IUserUnitOfWork> _uow;

        public AccountCreateUserTest()
        {
            _uow = new Mock<IUserUnitOfWork>() { CallBase = true };
            _accountCreateValidation = new AccountCreateValidation(_uow.Object);
            _accountValidation = new AccountValidation(_accountCreateValidation);
            _app = new Mock<AccountApplicationService>(_uow.Object, _accountValidation) { CallBase = true }.Object;
        }
        
        [Trait("Cadastrar Usuário", "Usuário Vazio")]
        [Category("User")]
        [Fact]
        public async Task Username_Vazio()
        {
            var dto = new AccountUserPostDto
            {
                Username = "",
                Password = "teste",
                Role = "admin"
            };

            _uow.Setup(x => x.UserRepository.Add(new User { Id = Guid.NewGuid() }));

            var result = await _app.CreateUser(dto);

            Assert.False(result.IsValid);
            Assert.Equal("O campo Usuário é obrigatório.", result.Errors.FirstOrDefault().ErrorMessage);
        }

        [Trait("Cadastrar Usuário", "Usuário Inválido")]
        [Category("User")]
        [Fact]
        public async Task Username_Invalido()
        {
            var dto = new AccountUserPostDto
            {
                Username = "testeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee",
                Password = "teste",
                Role = "admin"
            };

            var idUser = Guid.NewGuid();
            _uow.Setup(x => x.UserRepository.Add(new User { Id = idUser, Username = "felipe" }));

            var result = await _app.CreateUser(dto);

            Assert.False(result.IsValid);
            Assert.Equal("O campo Usuário deve possuir no máximo 50 caracteres.", result.Errors.FirstOrDefault().ErrorMessage);
        }

        [Trait("Cadastrar Usuário", "Senha Vazio")]
        [Category("User")]
        [Fact]
        public async Task Password_Vazio()
        {
            var dto = new AccountUserPostDto
            {
                Username = "teste",
                Password = "",
                Role = "admin"
            };

            _uow.Setup(a => a.UserRepository.Add(new User { Id = Guid.NewGuid() }));

            var result = await _app.CreateUser(dto);

            Assert.False(result.IsValid);
            Assert.Equal("O campo Senha é obrigatório.", result.Errors.FirstOrDefault().ErrorMessage);
        }

        [Trait("Cadastrar Usuário", "Função Vazio")]
        [Category("User")]
        [Fact]
        public async Task Role_Vazio()
        {
            var dto = new AccountUserPostDto
            {
                Username = "teste",
                Password = "teste",
                Role = ""
            };

            _uow.Setup(a => a.UserRepository.Add(new User { Id = Guid.NewGuid() }));

            var result = await _app.CreateUser(dto);

            Assert.False(result.IsValid);
            Assert.Equal("O campo Função é obrigatório.", result.Errors.FirstOrDefault().ErrorMessage);
        }
    }
}
