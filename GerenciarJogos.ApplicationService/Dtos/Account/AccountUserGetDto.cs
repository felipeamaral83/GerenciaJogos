using System;

namespace GerenciaJogos.ApplicationService.Dtos.Account
{
    public class AccountUserGetDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
