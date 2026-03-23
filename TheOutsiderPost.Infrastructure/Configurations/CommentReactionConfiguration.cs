using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    public class CommentReactionConfiguration : IEntityTypeConfiguration<CommentReaction>
    {
        public void Configure(EntityTypeBuilder<CommentReaction> builder)
        {
            builder.ToTable("CommentReactions");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId)
                .IsRequired()
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.Property(r => r.Type)
                .IsRequired();

            builder.HasIndex(r => new { r.CommentId, r.UserId })
                .IsUnique();

            builder.HasOne<Comment>()
                .WithMany()
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
