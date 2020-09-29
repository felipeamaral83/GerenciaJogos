using GerenciaJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciaJogos.Infrastructure.Data.Map
{
    public class BorrowedGameMap : IEntityTypeConfiguration<BorrowedGame>
    {
        public void Configure(EntityTypeBuilder<BorrowedGame> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LoanDate)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.BorrowedGames)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Game)
                .WithMany(x => x.BorrowedGames)
                .HasForeignKey(x => x.IdGame)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Friend)
                .WithMany(x => x.BorrowedGames)
                .HasForeignKey(x => x.IdFriend)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
