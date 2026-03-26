using TheOutsiderPost.Application.Contracts;
using TheOutsiderPost.Application.DTOs;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Application.UseCases
{
    public class CreatePostUseCase(IPostRepository _postRepository)
    {
        public async Task<CreatePostResponse> ExecuteAsync(CreatePostRequest request)
        {
            // Validate slug
            if (await _postRepository.SlugExistsAsync(request.Slug))
                throw new InvalidOperationException("Slug already exists.");

            // Create Domain Entity
            var post = new Post(
                request.Slug,
                request.Title,
                request.Summary,
                request.CreatedBy);

            // Get initial version
            var version = post.Versions.First();

            // Add content block
            foreach (var block in request.ContentBlocks)
            {
                version.AddContentBlock(new ContentBlock(
                    block.Type,
                    block.Value,
                    block.Order));
            }

            // Persist to database
            await _postRepository.AddAsync(post);
            await _postRepository.SaveChangesAsync();

            // Return response (could be just the new post ID or a more detailed DTO)
            return new CreatePostResponse(post.Id);
        }
    }
}
