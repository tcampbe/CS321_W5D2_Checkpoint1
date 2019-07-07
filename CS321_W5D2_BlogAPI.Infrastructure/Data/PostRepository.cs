using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class PostRepository : IPostRepository
    {
        public PostRepository(AppDbContext dbContext) 
        {  
        }

        public Post Get(int id)
        {
            // TODO: Implement Get(id). Include related Blog and Blog.User
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            // TODO: Implement GetBlogPosts, return all posts for given blog id
            // TODO: Include related Blog and AppUser
            throw new NotImplementedException();
        }

        public Post Add(Post Post)
        {
            // TODO: add Post
            throw new NotImplementedException();
        }

        public Post Update(Post Post)
        {
            // TODO: update Post
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            // TODO: get all posts
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            // TODO: remove Post
            throw new NotImplementedException();
        }

    }
}
