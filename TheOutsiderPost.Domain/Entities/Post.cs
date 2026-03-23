using TheOutsiderPost.Domain.Enums;

namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a blog post aggregate root.
    /// Handles the lifecycle, versioning, publication workflow,
    /// and relationships such as categories and comments.
    /// </summary>
    public class Post
    {
        private readonly List<PostVersion> _versions = new();
        private readonly List<PostCategory> _categories = new();
        private readonly List<Comment> _comments = new();

        /// <summary>
        /// Unique identifier of the post.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// URL-friendly identifier (slug) of the post.
        /// Cannot be modified after the post has been published.
        /// </summary>
        public string Slug { get; private set; }
        /// <summary>
        /// Indicates whether the post has ever been published at least once.
        /// </summary>
        public bool HasBeenPublished { get; private set; }

        /// <summary>
        /// Current status of the post in the publication workflow.
        /// </summary>
        public PostStatus Status { get; private set; }
        /// <summary>
        /// Scheduled date and time for automatic publication.
        /// Null if not scheduled.
        /// </summary>
        public DateTimeOffset? ScheduledPublishAt { get; private set; }

        /// <summary>
        /// Identifier of the user who created the post.
        /// </summary>
        public string CreatedBy { get; private set; }
        /// <summary>
        /// Date and time when the post was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Identifier of the user who last modified the post.
        /// </summary>
        public string? LastModifiedBy { get; private set; }
        /// <summary>
        /// Date and time of the last modification.
        /// </summary>
        public DateTimeOffset? LastModifiedAt { get; private set; }

        /// <summary>
        /// Identifier of the user who approved the post.
        /// </summary>
        public string? ApprovedBy { get; private set; }
        /// <summary>
        /// Date and time when the post was approved.
        /// </summary>
        public DateTimeOffset? ApprovedAt { get; private set; }

        /// <summary>
        /// Identifier of the user who published the post.
        /// </summary>
        public string? PublishedBy { get; private set; }
        /// <summary>
        /// Date and time when the post was published.
        /// </summary>
        public DateTimeOffset? PublishedAt { get; private set; }

        /// <summary>
        /// Identifier of the currently published version of the post.
        /// </summary>
        public int? CurrentVersionId { get; private set; }

        /// <summary>
        /// Collection of all versions of the post.
        /// </summary>
        public IReadOnlyCollection<PostVersion> Versions => _versions.AsReadOnly();
        /// <summary>
        /// Collection of categories associated with the post.
        /// </summary>
        public IReadOnlyCollection<PostCategory> Categories => _categories.AsReadOnly();
        /// <summary>
        /// Collection of comments associated with the post.
        /// </summary>
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        /// <summary>
        /// Private constructor for ORM usage.
        /// </summary>
        private Post() { }

        /// <summary>
        /// Initializes a new post in Draft status with its first version.
        /// </summary>
        /// <param name="slug">Unique URL-friendly identifier.</param>
        /// <param name="title">Title of the initial version.</param>
        /// <param name="summary">Summary of the initial version.</param>
        /// <param name="createdBy">User who creates the post.</param>
        /// <exception cref="ArgumentException">Thrown when slug is empty.</exception>
        public Post(string slug, string title, string summary, string createdBy)
        {
            if (string.IsNullOrWhiteSpace(slug))
                throw new ArgumentException("Slug cannot be empty.");

            Slug = slug;
            CreatedBy = createdBy;
            CreatedAt = DateTimeOffset.UtcNow;
            Status = PostStatus.Draft;

            // Always create version 1
            var version = new PostVersion(1, title, summary, createdBy);
            _versions.Add(version);
        }

        /// <summary>
        /// Updates the slug of the post.
        /// This operation is not allowed after the post has been published.
        /// </summary>
        /// <param name="newSlug">New slug value.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the post has already been published.
        /// </exception>
        public void UpdateSlug(string newSlug)
        {
            if (HasBeenPublished)
                throw new InvalidOperationException("Slug cannot be modified after first publication.");

            Slug = newSlug;
        }

        /// <summary>
        /// Creates a new version of the post content.
        /// Automatically moves the post to PendingReview status.
        /// </summary>
        /// <param name="title">Title of the new version.</param>
        /// <param name="summary">Summary of the new version.</param>
        /// <param name="modifiedBy">User making the modification.</param>
        /// <returns>The newly created version.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the post is archived.
        /// </exception>
        public PostVersion CreateNewVersion(string title, string summary, string modifiedBy)
        {
            if (Status == PostStatus.Archived)
                throw new InvalidOperationException("Cannot edit archived post.");

            var nextVersion = _versions.Count + 1;

            var version = new PostVersion(nextVersion, title, summary, modifiedBy);
            _versions.Add(version);

            LastModifiedBy = modifiedBy;
            LastModifiedAt = DateTimeOffset.UtcNow;

            ScheduledPublishAt = null;
            Status = PostStatus.PendingReview;

            return version;
        }

        /// <summary>
        /// Sends the post to the review stage.
        /// Only allowed when the post is in Draft status.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the post is not in Draft status.
        /// </exception>
        public void SendToReview()
        {
            if (Status != PostStatus.Draft)
                throw new InvalidOperationException("Only drafts can be sent to review.");

            Status = PostStatus.PendingReview;
        }

        /// <summary>
        /// Approves the post, allowing it to be published or scheduled.
        /// </summary>
        /// <param name="approvedBy">User approving the post.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the post is not in PendingReview status.
        /// </exception>
        public void Approve(string approvedBy)
        {
            if (Status != PostStatus.PendingReview)
                throw new InvalidOperationException("Post must be pending review.");

            ApprovedBy = approvedBy;
            ApprovedAt = DateTimeOffset.UtcNow;
            Status = PostStatus.Approved;
        }

        /// <summary>
        /// Schedules the post for future publication.
        /// </summary>
        /// <param name="publishAt">Date and time when the post should be published.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the post is not approved.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the scheduled date is not in the future.
        /// </exception>
        public void SchedulePublication(DateTimeOffset publishAt)
        {
            if (Status != PostStatus.Approved)
                throw new InvalidOperationException("Only approved posts can be scheduled.");

            if (publishAt <= DateTimeOffset.UtcNow)
                throw new ArgumentException("Scheduled date must be in the future.");

            ScheduledPublishAt = publishAt;
        }

        /// <summary>
        /// Cancels any scheduled publication.
        /// </summary>  
        public void CancelScheduledPublication()
        {
            ScheduledPublishAt = null;
        }

        /// <summary>
        /// Publishes the post immediately using the latest version.
        /// </summary>
        /// <param name="publishedBy">User publishing the post.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the post is not approved.
        /// </exception>
        public void Publish(string publishedBy)
        {
            if (Status != PostStatus.Approved)
                throw new InvalidOperationException("Post must be approved.");

            var latestVersion = _versions
                .OrderByDescending(v => v.VersionNumber)
                .First();

            CurrentVersionId = latestVersion.Id;

            PublishedBy = publishedBy;
            PublishedAt = DateTimeOffset.UtcNow;
            Status = PostStatus.Published;
            HasBeenPublished = true;

            ScheduledPublishAt = null;
        }

        /// <summary>
        /// Publishes the post automatically if the scheduled time has been reached.
        /// </summary>
        /// <param name="now">Current date and time.</param>
        public void PublishIfScheduled(DateTimeOffset now)
        {
            if (Status == PostStatus.Approved &&
                ScheduledPublishAt.HasValue &&
                ScheduledPublishAt <= now)
            {
                Publish(ApprovedBy!);
            }
        }

        /// <summary>
        /// Adds a category to the post if it is not already associated.
        /// </summary>
        /// <param name="categoryId">Identifier of the category.</param>
        public void AddCategory(int categoryId)
        {
            if (_categories.Any(c => c.CategoryId == categoryId))
                return;

            _categories.Add(new PostCategory(Id, categoryId));
        }
    }
}
