using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class BlogRepository : Repository<Blog, int>, IBlogRepository
    {
        public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
