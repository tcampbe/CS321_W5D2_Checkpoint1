using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class BlogRepository : Repository<Blog, int>, IBlogRepository
    {
        public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public override IEnumerable<Blog> GetAll()
        {
            return _dbContext.Blogs.Include(b => b.User).ToList();
        }

        public override Blog Get(int id)
        {
            return _dbContext.Blogs.Include(b => b.User).SingleOrDefault(b => b.Id == id);
        }

        public bool DoesBlogBelongToUser(int blogId, string userId)
        {
            var blog = this.Get(blogId);
            return blog.UserId == userId;
        }
    }
}
