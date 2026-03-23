using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.AuthorId)
                .IsRequired()
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(DomainConstants.Comment.ContentMaxLength);

            builder.HasIndex(c => c.PostId);

            builder.HasOne<Comment>()
                .WithMany()
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Comment>()
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => new { c.PostId, c.CreatedAt });
        }
    }
}
