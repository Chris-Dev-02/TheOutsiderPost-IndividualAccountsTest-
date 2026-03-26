using TheOutsiderPost.Domain.Enums;

namespace TheOutsiderPost.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Slug"></param>
    /// <param name="Title"></param>
    /// <param name="Summary"></param>
    /// <param name="CreatedBy"></param>
    /// <param name="ContentBlocks"></param>
    public record CreatePostRequest(
        string Slug,
        string Title,
        string Summary,
        string CreatedBy,
        List<CreateContentBlockDto> ContentBlocks);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="Value"></param>
    /// <param name="Order"></param>
    public record CreateContentBlockDto(
        ContentBlockType Type,
        string Value,
        int Order);
}
