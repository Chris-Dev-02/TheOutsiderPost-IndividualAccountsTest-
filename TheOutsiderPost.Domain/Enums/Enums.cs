namespace TheOutsiderPost.Domain.Enums
{
    /// <summary>
    /// Represents the current status of a post.
    /// Determines visibility, review state, and publication workflow.
    /// </summary>
    public enum PostStatus
    {
        /// <summary>
        /// Post is created as a draft by an editor.
        /// </summary>
        Draft = 1,
        /// <summary>
        /// Post is under review by a reviewer.
        /// </summary>
        PendingReview = 2,
        /// <summary>
        /// Post has been approved for publication.
        /// </summary>
        Approved = 3,
        /// <summary>
        /// Post is published and visible to all users.
        /// </summary>
        Published = 4,
        /// <summary>
        /// Post has been unpublished and is no longer visible to common users.
        /// </summary>
        Unpublished = 5,
        /// <summary>
        /// Post is hidden by moderation or admin actions.
        /// </summary>
        Hidden = 6,
        /// <summary>
        /// Post is archived for historical purposes (read-only).
        /// </summary>
        Archived = 7,
        /// <summary>
        /// Post is scheduled to be published at a future date.
        /// </summary>
        Scheduled = 8
    }

    /// <summary>
    /// Represents the type of a content block in a post version.
    /// </summary>
    public enum ContentBlockType
    {
        /// <summary>
        /// Standard paragraph of text.
        /// </summary>
        Paragraph = 1,
        /// <summary>
        /// Heading or title block.
        /// </summary>
        Heading = 2,
        /// <summary>
        /// Image block with optional caption/alt text.
        /// </summary>
        Image = 3,
        /// <summary>
        /// Video block embedded in the post.
        /// </summary>
        Video = 4,
        /// <summary>
        /// Quoted text block.
        /// </summary>
        Quote = 5,
        /// <summary>
        /// Embedded content (e.g., tweets, code snippets, media embeds).
        /// </summary>
        Embed = 6
    }

    /// <summary>
    /// Represents the current status of a comment.
    /// </summary>
    public enum CommentStatus
    {
        /// <summary>
        /// Comment is visible to all users.
        /// </summary>
        Active = 1,
        /// <summary>
        /// Comment is hidden by a moderator.
        /// </summary>
        Hidden = 2,
        /// <summary>
        /// Comment has been deleted (soft delete).
        /// </summary>
        Deleted = 3,
        /// <summary>
        /// Comment has been reported by the community.
        /// </summary>
        Reported = 4
    }

    /// <summary>
    /// Represents the type of reaction a user can give to a post or comment.
    /// </summary>
    public enum ReactionType
    {
        /// <summary>
        /// Positive reaction (like).
        /// </summary>
        Like = 1,
        /// <summary>
        /// Negative reaction (dislike).
        /// </summary>
        Dislike = 2
    }
}
