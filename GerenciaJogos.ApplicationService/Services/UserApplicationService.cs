using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using GerenciarJogos.ApplicationService.Dtos.User;
using GerenciarJogos.Infrastructure.Authorization.Services;
using System.Linq;

namespace GerenciarJogos.ApplicationService.Services
{
    public class UserApplicationService
    {
        private readonly IUserUnitOfWork _uow;

        public UserApplicationService(IUserUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserGetDto Login(UserLoginDto dto)
        {
            var user = _uow.UserRepository.Get(dto.Username, dto.Password);
            var token = TokenService.GenerateToken(user);

            var userGetDto = new UserGetDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Token = token
            };

            return userGetDto;
        }
    }
}
