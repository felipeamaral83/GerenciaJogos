using GerenciaJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciaJogos.Infrastructure.Data.Map
{
    public class FriendMap : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Nickname)
                .HasMaxLength(50);

            builder.Property(x => x.Whatsapp)
                .HasMaxLength(11);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Friends)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
