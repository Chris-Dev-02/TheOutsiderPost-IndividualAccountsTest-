using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    internal class ContentBlockConfiguration : IEntityTypeConfiguration<ContentBlock>
    {
        public void Configure(EntityTypeBuilder<ContentBlock> builder)
        {
            builder.ToTable("ContentBlocks");

            builder.HasKey(cb => cb.Id);

            builder.Property(cb => cb.Value)
                .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired();

            builder.HasIndex(cb => new { cb.PostVersionId, cb.Order });
        }
    }
}
