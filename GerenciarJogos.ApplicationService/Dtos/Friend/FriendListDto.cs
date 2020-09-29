using System;

namespace GerenciaJogos.ApplicationService.Dtos.Friend
{
    public class FriendListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Whatsapp { get; set; }
    }
}
