using TheOutsiderPost.Domain.Enums;

namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a comment associated with a post.
    /// Supports replies, reporting, and status management (active, hidden, deleted, reported).
    /// </summary>
    public class Comment
    {
        private readonly List<CommentReport> _reports = new();

        /// <summary>
        /// Unique identifier of the comment.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Identifier of the post to which this comment belongs.
        /// </summary>
        public int PostId { get; private set; }

        /// <summary>
        /// Optional identifier of the parent comment, for threaded replies.
        /// Null if this comment is a top-level comment.
        /// </summary>
        public int? ParentCommentId { get; private set; }

        /// <summary>
        /// Identifier of the user who authored the comment.
        /// </summary>
        public string AuthorId { get; private set; }
        /// <summary>
        /// Text content of the comment.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Current status of the comment (Active, Hidden, Deleted, Reported).
        /// </summary>
        public CommentStatus Status { get; private set; }
        /// <summary>
        /// Date and time when the comment was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Collection of reports associated with this comment.
        /// Adding a report sets the status to Reported.
        /// </summary>
        public IReadOnlyCollection<CommentReport> Reports => _reports.AsReadOnly();
        /// <summary>
        /// Collection of replies to this comment.
        /// </summary>
        public ICollection<Comment> Replies { get; private set; }

        /// <summary>
        /// Private constructor required by ORM frameworks.
        /// </summary>
        private Comment() { }

        /// <summary>
        /// Initializes a new comment, optionally as a reply to a parent comment.
        /// </summary>
        /// <param name="postId">Identifier of the post this comment belongs to.</param>
        /// <param name="authorId">Identifier of the author of the comment.</param>
        /// <param name="content">Text content of the comment.</param>
        /// <param name="parentCommentId">Optional parent comment ID if this is a reply.</param>
        public Comment(int postId, string authorId, string content, int? parentCommentId = null)
        {
            PostId = postId;
            AuthorId = authorId;
            Content = content;
            ParentCommentId = parentCommentId;
            Status = CommentStatus.Active;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Hides the comment from public view without deleting it.
        /// </summary>
        public void Hide()
        {
            Status = CommentStatus.Hidden;
        }

        /// <summary>
        /// Marks the comment as deleted.
        /// </summary>
        public void Delete()
        {
            Status = CommentStatus.Deleted;
        }

        /// <summary>
        /// Adds a report to the comment.
        /// Automatically sets the comment status to Reported.
        /// </summary>
        /// <param name="report">The report object to add.</param>
        public void AddReport(CommentReport report)
        {
            _reports.Add(report);
            Status = CommentStatus.Reported;
        }
    }
}
