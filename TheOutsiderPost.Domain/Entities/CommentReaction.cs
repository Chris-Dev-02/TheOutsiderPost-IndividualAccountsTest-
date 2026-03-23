using TheOutsiderPost.Domain.Enums;

namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a reaction (like, dislike, etc.) to a specific comment.
    /// Tracks which user reacted and the type of reaction.
    /// </summary>
    public class CommentReaction
    {
        /// <summary>
        /// Unique identifier of the comment reaction.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Identifier of the comment that received the reaction.
        /// </summary>
        public int CommentId { get; private set; }
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
        private CommentReaction() { }

        /// <summary>
        /// Initializes a new reaction to a comment.
        /// </summary>
        /// <param name="commentId">Identifier of the comment to react to.</param>
        /// <param name="userId">Identifier of the user making the reaction.</param>
        /// <param name="type">Type of the reaction.</param>
        public CommentReaction(int postId, string userId, ReactionType type)
        {
            CommentId = postId;
            UserId = userId;
            Type = type;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Updates the type of the reaction.
        /// </summary>
        /// <param name="newType">New reaction type.</param>
        public void UpdateReaction(ReactionType newType)
        {
            Type = newType;
        }
    }
}
