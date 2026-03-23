using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheOutsiderPost.Domain;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(DomainConstants.Category.NameMaxLength);

            builder.Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(DomainConstants.Category.SlugMaxLength);

            builder.Property(c => c.Description)
                .IsRequired(false);

            builder.HasIndex(c => c.Slug)
                .IsUnique();
        }
    }
}
