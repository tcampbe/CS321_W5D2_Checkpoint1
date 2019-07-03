using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W5D2_BlogAPI.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W5D2_BlogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private List<Blog> _blogs = new List<Blog>
        {
                new Blog
                {
                    Id = 1,
                    Name = "Yada, Yada, Yada",
                    Description = "A blog about nothing.",
                },
                new Blog
                {
                    Id = 2,
                    Name = "Random Nonsense",
                    Description = "Just what it says."
                }
        };

        // GET: api/values
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _blogs;
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            return _blogs.SingleOrDefault(b => b.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Blog blog)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Blog blog)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
