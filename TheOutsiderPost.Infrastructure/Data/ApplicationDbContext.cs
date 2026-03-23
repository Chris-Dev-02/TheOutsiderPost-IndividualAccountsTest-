using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheOutsiderPost.Domain.Entities;

namespace IndividualAccountsTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<PostVersion> PostVersions => Set<PostVersion>();
        public DbSet<ContentBlock> ContentBlocks => Set<ContentBlock>();

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<PostCategory> PostCategories => Set<PostCategory>();

        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<CommentReport> CommentReports => Set<CommentReport>();

        public DbSet<PostReaction> PostReactions => Set<PostReaction>();
        public DbSet<CommentReaction> CommentReactions => Set<CommentReaction>();

        public DbSet<UserFavoritePost> UserFavoritePosts => Set<UserFavoritePost>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
