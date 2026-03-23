using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    public class PostReactionCnfiguration : IEntityTypeConfiguration<PostReaction>
    {
        public void Configure(EntityTypeBuilder<PostReaction> builder)
        {
            builder.ToTable("PostReactions");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId)
                .IsRequired()
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.Property(r => r.Type)
                .IsRequired();

            builder.HasIndex(r => new { r.PostId, r.UserId })
                .IsUnique();

            builder.HasOne<Post>()
                .WithMany()
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
