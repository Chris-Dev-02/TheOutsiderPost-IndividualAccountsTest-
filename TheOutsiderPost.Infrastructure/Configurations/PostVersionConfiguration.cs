using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    public class PostVersionConfiguration : IEntityTypeConfiguration<PostVersion>
    {
        public void Configure(EntityTypeBuilder<PostVersion> builder)
        {
            builder.ToTable("PostVersions");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(DomainConstants.Post.TitleMaxLength);

            builder.Property(v => v.Summary)
                .IsRequired()
                .HasMaxLength(DomainConstants.Post.SummaryMaxLength);

            builder.Property(v => v.CreatedBy)
                .IsRequired()
                .HasMaxLength(450);

            builder.HasIndex(v => new { v.PostId, v.VersionNumber })
                .IsUnique();

            builder.HasMany(v => v.ContentBlocks)
                .WithOne()
                .HasForeignKey(cb => cb.PostVersionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata
                .FindNavigation(nameof(PostVersion.ContentBlocks))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
