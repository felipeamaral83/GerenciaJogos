using System;
using System.Collections.Generic;

namespace GerenciaJogos.Domain.Entities
{
    public class Game
    {
        public Game()
        {
            Id = Guid.NewGuid();
            Borrowed = false;
        }
        
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public bool Borrowed { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<BorrowedGame> BorrowedGames { get; set; }
    }
}
