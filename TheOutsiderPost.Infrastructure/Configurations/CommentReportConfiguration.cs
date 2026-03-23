using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    public class CommentReportConfiguration : IEntityTypeConfiguration<CommentReport>
    {
        public void Configure(EntityTypeBuilder<CommentReport> builder)
        {
            builder.ToTable("CommentReports");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId)
                .IsRequired()
                .HasMaxLength(DomainConstants.Common.IdMaxLength);

            builder.Property(r => r.Reason)
            .IsRequired()
            .HasMaxLength(DomainConstants.Report.ReasonMaxLength);

            builder.HasIndex(r => new { r.CommentId, r.UserId })
                .IsUnique();

            builder.Metadata
                .FindNavigation(nameof(Comment.Reports))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
