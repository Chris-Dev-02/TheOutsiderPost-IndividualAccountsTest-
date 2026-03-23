using TheOutsiderPost.Domain.Enums;

namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a block of content within a specific post version.
    /// Can be text, image, video, or other structured content types.
    /// </summary>
    public class ContentBlock
    {
        /// <summary>
        /// Unique identifier of the content block.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Identifier of the post version this block belongs to.
        /// </summary>
        public int PostVersionId { get; private set; }

        /// <summary>
        /// Type of the content block (Text, Image, Video, etc.).
        /// </summary>
        public ContentBlockType Type { get; private set; }
        /// <summary>
        /// Main content of the block (text, image URL, video URL, etc.).
        /// Cannot be empty or null.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Optional caption for the content block (e.g., for images or videos).
        /// </summary>
        public string? Caption { get; private set; }
        /// <summary>
        /// Optional alternative text for accessibility (e.g., for images).
        /// </summary>
        public string? AltText { get; private set; }

        /// <summary>
        /// Display order of the content block within the post version.
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Display order of the content block within the post version.
        /// </summary>
        private ContentBlock() { }

        /// <summary>
        /// Initializes a new content block with a specific type, value, and display order.
        /// </summary>
        /// <param name="type">Type of the content block.</param>
        /// <param name="value">Main content of the block.</param>
        /// <param name="order">Display order within the post version.</param>
        /// <exception cref="ArgumentException">Thrown when the content value is empty or whitespace.</exception>
        public ContentBlock(ContentBlockType type, string value, int order)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Content cannot be empty.");

            Type = type;
            Value = value;
            Order = order;
        }

        /// <summary>
        /// Updates the display order of the content block within the post version.
        /// </summary>
        /// <param name="newOrder">New order value.</param>
        public void UpdateOrder(int newOrder)
        {
            Order = newOrder;
        }
    }
}
