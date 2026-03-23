using System;
namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a report made by a user on a specific comment.
    /// Tracks the reason for the report, its resolution status, and timestamps.
    /// </summary>
    public class CommentReport
    {
        /// <summary>
        /// Unique identifier of the comment report.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Identifier of the comment being reported.
        /// </summary>

        public int CommentId { get; private set; }
        /// <summary>
        /// Identifier of the user who made the report.
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// Reason provided by the user for reporting the comment.
        /// Cannot be empty or whitespace.
        /// </summary>
        public string Reason { get; private set; }
        /// <summary>
        /// Indicates whether the report has been resolved.
        /// </summary>
        public bool IsResolved { get; private set; }
        /// <summary>
        /// Date and time when the report was created.
        /// </summary>
        /// </summary>
        public DateTimeOffset ReportedAt { get; private set; }
        /// <summary>
        /// Date and time when the report was resolved.
        /// Null if the report has not yet been resolved.
        /// </summary>
        public DateTimeOffset? ResolvedAt { get; private set; }

        /// <summary>
        /// Private constructor required by ORM frameworks.
        /// </summary>
        private CommentReport() { }

        /// <summary>
        /// Initializes a new comment report with a reason.
        /// </summary>
        /// <param name="commentId">Identifier of the comment being reported.</param>
        /// <param name="userId">Identifier of the user creating the report.</param>
        /// <param name="reason">Reason for reporting the comment.</param>
        /// <exception cref="ArgumentException">Thrown if the reason is empty or whitespace.</exception>
        public CommentReport(int commentId, string userId, string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Report reason cannot be empty.");

            CommentId = commentId;
            UserId = userId;
            Reason = reason;
            ReportedAt = DateTimeOffset.UtcNow;
            IsResolved = false;
        }

        /// <summary>
        /// Marks the report as resolved and sets the resolution timestamp.
        /// </summary>
        public void Resolve()
        {
            IsResolved = true;
            ResolvedAt = DateTimeOffset.UtcNow;
        }
    }
}
