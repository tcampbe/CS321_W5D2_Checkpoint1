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

        // TODO: Implement Get(id). Include related Blog and AppUser
        public override Post Get(int id)
        {
            return _dbContext.Posts
                .Include(p => p.Blog)
                .ThenInclude(b => b.User)
                .SingleOrDefault(p => p.Id == id);
        }

        // TODO: Implement GetBlogPosts, return all posts for given blog
        // TODO: Include related Blog and AppUser
        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _dbContext.Posts
                .Include(p => p.Blog)
                .ThenInclude(b => b.User)
                .Where(p => p.BlogId == blogId)
                .ToList();
        }

        // TODO: Implement GetPostComments, return all Comments for given Post
        public IEnumerable<Comment> GetPostComments(int postId)
        {
            return _dbContext.Comments
                .Where(c => c.PostId == postId)
                .ToList();
        }

        public Comment AddComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
            return comment;
        }
    }
}
