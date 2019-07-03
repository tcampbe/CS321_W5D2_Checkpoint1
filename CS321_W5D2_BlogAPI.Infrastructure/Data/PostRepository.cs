using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class PostRepository : Repository<Post, int>, IPostRepository
    {
        public PostRepository(AppDbContext dbContext) : base(dbContext)
        {  
        }

        public override Post Get(int id)
        {
            return _dbContext.Posts
                .Include(p => p.Blog)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _dbContext.Posts
                .Include(p => p.Blog)
                .Where(p => p.BlogId == blogId)
                .ToList();
        }

        public IEnumerable<Comment> GetPostComments(int postId)
        {
            return _dbContext.Comments
                .Where(c => c.PostId == postId)
                .ToList();
        }
    }
}
