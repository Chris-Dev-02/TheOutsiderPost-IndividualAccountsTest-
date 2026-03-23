using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    public class USerFavoritePostConfiguration : IEntityTypeConfiguration<UserFavoritePost>
    {
        public void Configure(EntityTypeBuilder<UserFavoritePost> builder)
        {
            builder.ToTable("UserFavoritePosts");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.UserId)
                .IsRequired()
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.HasOne<Post>()
                .WithMany()
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(f => new { f.PostId, f.UserId })
                .IsUnique();

        }
    }
}
