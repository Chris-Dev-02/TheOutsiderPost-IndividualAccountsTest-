using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Slug)
                .IsUnique();

            builder.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(DomainConstants.Post.SlugMaxLength);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p => p.CreatedBy)
                .IsRequired()
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.Property(p => p.LastModifiedBy)
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.Property(p => p.ApprovedBy)
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.Property(p => p.PublishedBy)
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.HasMany(p => p.Versions)
                .WithOne()
                .HasForeignKey(v => v.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Categories)
                .WithOne()
                .HasForeignKey(pc => pc.PostId);

            builder.HasMany(p => p.Comments)
                .WithOne()
                .HasForeignKey(c => c.PostId);

            builder.HasOne<PostVersion>()
                .WithMany()
                .HasForeignKey(p => p.CurrentVersionId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Navigation(p => p.Versions)
            //    .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Post.Versions))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Post.Categories))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Post.Comments))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            // Index used in scheduled posts
            builder.HasIndex(p => new { p.Status, p.ScheduledPublishAt });
            // Idenx used in posts not scheduled
            builder.HasIndex(p => new {p.Status, p.PublishedAt });
        }
    }
}
