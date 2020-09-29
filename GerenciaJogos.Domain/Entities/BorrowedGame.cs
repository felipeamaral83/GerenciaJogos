using System;

namespace GerenciaJogos.Domain.Entities
{
    public class BorrowedGame
    {
        public BorrowedGame()
        {
            Id = Guid.NewGuid();
            LoanDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdGame { get; set; }
        public Guid IdFriend { get; set; }
        public DateTime LoanDate { get; set; }
        public virtual User User { get; set; }
        public virtual Game Game { get; set; }
        public virtual Friend Friend { get; set; }
    }
}
