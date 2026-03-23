namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a post marked as favorite by a user.
    /// Tracks which user favorited which post and when.
    /// </summary>
    public class UserFavoritePost
    {
        /// <summary>
        /// Unique identifier of the favorite record.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Identifier of the post marked as favorite.
        /// </summary>
        public int PostId { get; private set; }
        /// <summary>
        /// Identifier of the user who favorited the post.
        /// </summary>
        public string UserId { get; private set; }
        /// <summary>
        /// Date and time when the post was marked as favorite.
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Private constructor required by ORM frameworks.
        /// </summary>
        private UserFavoritePost() { }

        /// <summary>
        /// Initializes a new record indicating that a user has favorited a post.
        /// </summary>
        /// <param name="postId">Identifier of the post being favorited.</param>
        /// <param name="userId">Identifier of the user who favorites the post.</param>
        public UserFavoritePost(int postId, string userId)
        {
            PostId = postId;
            UserId = userId;
            CreatedAt = DateTimeOffset.UtcNow;
        }
    }
}
