using System;
using System.Collections.Generic;

namespace GerenciaJogos.Domain.Entities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual IEnumerable<Friend> Friends { get; set; }
        public virtual IEnumerable<Game> Games { get; set; }
        public virtual IEnumerable<BorrowedGame> BorrowedGames { get; set; }
    }
}