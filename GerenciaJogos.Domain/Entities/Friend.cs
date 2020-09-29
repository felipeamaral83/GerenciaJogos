using System;
using System.Collections.Generic;

namespace GerenciaJogos.Domain.Entities
{
    public class Friend
    {
        public Friend()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Whatsapp { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<BorrowedGame> BorrowedGames { get; set; }
    }
}
