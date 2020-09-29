using System;

namespace GerenciaJogos.ApplicationService.Dtos.Game
{
    public class GameMyGamesDto
    {
        public Guid IdGame { get; set; }
        public Guid? IdBorrowedGame { get; set; }
        public string Game { get; set; }
        public string Friend { get; set; }
        public string Borrowed { get; set; }
        public DateTime? LoanDate { get; set; }
    }
}
