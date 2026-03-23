using TheOutsiderPost.Domain.Enums;

namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a reaction (like, dislike, etc.) made by a user on a specific post.
    /// Tracks which user reacted, the type of reaction, and the timestamp.
    /// </summary>
    public class PostReaction
    {
        /// <summary>
        /// Unique identifier of the post reaction.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Identifier of the post that received the reaction.
        /// </summary>
        public int PostId { get; private set; }
        /// <summary>
        /// Identifier of the user who made the reaction.
        /// </summary>
        public string UserId { get; private set; }
        /// <summary>
        /// Type of reaction (e.g., Like, Dislike, etc.).
        /// </summary>
        public ReactionType Type { get; private set; }
        /// <summary>
        /// Date and time when the reaction was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Private constructor required by ORM frameworks.
        /// </summary>
        private PostReaction() { }

        /// <summary>
        /// Initializes a new reaction to a post.
        /// </summary>
        /// <param name="postId">Identifier of the post receiving the reaction.</param>
        /// <param name="userId">Identifier of the user reacting to the post.</param>
        /// <param name="type">Type of reaction.</param>
        public PostReaction(int postId, string userId, ReactionType type)
        {
            PostId = postId;
            UserId = userId;
            Type = type;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Updates the type of the reaction.
        /// </summary>
        /// <param name="newType">New type of reaction.</param>
        public void UpdateReaction(ReactionType newType)
        {
            Type = newType;
        }
    }
}
