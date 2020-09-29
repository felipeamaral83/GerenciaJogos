using System;

namespace GerenciarJogos.ApplicationService.Dtos.User
{
    public class UserGetDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
