namespace TheOutsiderPost.Domain.Entities
{
    /// <summary>
    /// Represents a category for organizing posts.
    /// Categories have a name, slug, and description.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Unique identifier of the category.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Name of the category.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// URL-friendly identifier for the category.
        /// </summary>
        public string Slug { get; private set; }
        /// <summary>
        /// Description of the category, explaining its purpose or content.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Private constructor for ORM frameworks like Entity Framework.
        /// </summary>
        private Category() { } // EF

        /// <summary>
        /// Initializes a new category with name, slug, and description.
        /// </summary>
        /// <param name="name">Name of the category.</param>
        /// <param name="slug">URL-friendly slug of the category.</param>
        /// <param name="description">Description of the category.</param>
        public Category(string name, string slug, string description)
        {
            Name = name;
            Slug = slug;
            Description = description;
        }

        /// <summary>
        /// Updates the name and description of the category.
        /// </summary>
        /// <param name="name">New name for the category.</param>
        /// <param name="description">New description for the category.</param>
        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
