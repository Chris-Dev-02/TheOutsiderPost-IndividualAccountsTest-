using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOutsiderPost.Domain.Entities;

namespace TheOutsiderPost.Application.Contracts
{
    public interface IPostRepository
    {
        Task SaveChangesAsync();

        Task<bool> SlugExistsAsync(string slug);

        Task AddAsync(Post post);

        Task<Post?> GetByIdAsync(int id);
    }
}
