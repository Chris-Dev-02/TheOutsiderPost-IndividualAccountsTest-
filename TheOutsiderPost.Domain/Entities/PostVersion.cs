namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a specific version of a post.
    /// Each version contains its own title, summary, and structured content blocks.
    /// </summary>
    public class PostVersion
    {
        private readonly List<ContentBlock> _contentBlocks = new();

        /// <summary>
        /// Unique identifier of the post version.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Identifier of the post to which this version belongs.
        /// </summary>
        public int PostId { get; private set; }

        /// <summary>
        /// Sequential number of the version within the post.
        /// Starts at 1 and increments with each new version.
        /// </summary>
        public int VersionNumber { get; private set; }
        /// <summary>
        /// Title of the post for this specific version.
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// Short summary or excerpt describing this version of the post.
        /// </summary>
        public string Summary { get; private set; }

        /// <summary>
        /// Identifier of the user who created this version.
        /// </summary>
        public string CreatedBy { get; private set; }
        /// <summary>
        /// Date and time when this version was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Collection of structured content blocks that compose the body of the post.
        /// </summary>
        public IReadOnlyCollection<ContentBlock> ContentBlocks => _contentBlocks.AsReadOnly();

        /// <summary>
        /// Private constructor required by ORM frameworks.
        /// </summary>
        private PostVersion() { }

        /// <summary>
        /// Initializes a new instance of a post version.
        /// </summary>
        /// <param name="versionNumber">Sequential version number.</param>
        /// <param name="title">Title of the version.</param>
        /// <param name="summary">Summary of the version.</param>
        /// <param name="createdBy">User who creates this version.</param>
        public PostVersion(int versionNumber, string title, string summary, string createdBy)
        {
            VersionNumber = versionNumber;
            Title = title;
            Summary = summary;
            CreatedBy = createdBy;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Adds a content block to this version.
        /// Content blocks represent structured pieces of content (e.g., paragraphs, images, quote).
        /// </summary>
        /// <param name="block">The content block to add.</param>
        public void AddContentBlock(ContentBlock block)
        {
            _contentBlocks.Add(block);
        }
    }
}
