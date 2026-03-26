namespace TheOutsiderPost.Application.DTOs
{
    /// <summary>
    /// Represents the response returned after successfully creating a post.
    /// </summary>
    /// <remarks>This record encapsulates the identifier of the newly created post. Use the <see
    /// cref="PostId"/> property to access the unique identifier assigned to the post.</remarks>
    /// <param name="PostId"></param>
    public record CreatePostResponse(int PostId);
}
