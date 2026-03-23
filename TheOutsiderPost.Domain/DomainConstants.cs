using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOutsiderPost.Domain
{
    /// <summary>
    /// Contains domain-wide constant values used for validation and constraints.
    /// </summary>
    public class DomainConstants
    {
        /// <summary>
        /// Common constants used across the domain.
        /// </summary>
        public static class Common
        {
            /// <summary>
            /// Maximum length for identifiers (IDs) across entities.
            /// </summary>
            public const int IdMaxLength = 450;
        }

        /// <summary>
        /// Constants related to posts.
        /// </summary>
        public static class Post
        {
            /// <summary>
            /// Maximum length of the post slug.
            /// </summary>
            public const int SlugMaxLength = 200;

            /// <summary>
            /// Maximum length of the post title.
            /// </summary>
            public const int TitleMaxLength = 300;

            /// <summary>
            /// Maximum length of the post summary.
            /// </summary>
            public const int SummaryMaxLength = 2000;
        }

        /// <summary>
        /// Constants related to categories.
        /// </summary>
        public static class Category
        {
            /// <summary>
            /// Maximum length of the category name.
            /// </summary>
            public const int NameMaxLength = 150;

            /// <summary>
            /// Maximum length of the category slug.
            /// </summary>
            public const int SlugMaxLength = 150;
        }

        /// <summary>
        /// Constants related to comments.
        /// </summary>
        public static class Comment
        {
            /// <summary>
            /// Maximum length of a comment's content.
            /// </summary>
            public const int ContentMaxLength = 2000;
        }

        /// <summary>
        /// Constants related to comment reports.
        /// </summary>
        public static class Report
        {
            /// <summary>
            /// Maximum length for the reason provided in a report.
            /// </summary>
            public const int ReasonMaxLength = 1000;
        }

        /// <summary>
        /// Constants related to users.
        /// </summary>
        public static class User
        {
            /// <summary>
            /// Maximum length of a user's identifier.
            /// </summary>
            public const int UserIdLength = 450;
        }
    }
}
