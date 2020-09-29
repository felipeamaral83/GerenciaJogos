using System;

namespace GerenciaJogos.ApplicationService.Dtos.BorrowedGame
{
    public class BorrowedGamePostDto
    {
        public Guid IdGame { get; set; }
        public Guid IdFriend { get; set; }
    }
}
