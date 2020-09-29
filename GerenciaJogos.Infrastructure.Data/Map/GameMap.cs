using GerenciaJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciaJogos.Infrastructure.Data.Map
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Borrowed)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
