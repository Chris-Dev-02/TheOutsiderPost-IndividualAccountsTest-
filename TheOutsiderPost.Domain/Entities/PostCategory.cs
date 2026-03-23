namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents the association between a post and a category.
    /// This is a many-to-many linking entity connecting posts with categories.
    /// </summary>
    public class PostCategory
    {
        /// <summary>
        /// Identifier of the post.
        /// </summary>
        public int PostId { get; private set; }
        /// <summary>
        /// Identifier of the category associated with the post.
        /// </summary>
        public int CategoryId { get; private set; }

        /// <summary>
        /// Private constructor required by ORM frameworks.
        /// </summary>
        private PostCategory() { }

        /// <summary>
        /// Initializes a new association between a post and a category.
        /// </summary>
        /// <param name="postId">Identifier of the post.</param>
        /// <param name="categoryId">Identifier of the category.</param>
        public PostCategory(int postId, int categoryId)
        {
            PostId = postId;
            CategoryId = categoryId;
        }
    }
}
