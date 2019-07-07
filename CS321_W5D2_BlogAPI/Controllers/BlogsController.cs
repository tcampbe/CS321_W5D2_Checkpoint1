using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W5D2_BlogAPI.ApiModels;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W5D2_BlogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/bogs
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new BlogModel[] {
                new BlogModel
                {
                    Id = 1,
                    Name = "Fix Me!",
                    Description = "Implement GET /api/blogs",
                    AuthorName = "unknown",
                }
            });
        }

        // GET api/blogs/{id}
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new BlogModel
            {
                Id = id,
                Name = "Fix Me!",
                Description = "Implement GET /api/blogs/{id}",
                AuthorName = "unknown",
            });
        }

        // POST api/blogs
        [HttpPost]
        public IActionResult Post([FromBody]Blog blog)
        {
            return Ok(_blogService.Add(blog).ToApiModel());
        }

        // PUT api/blogs/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Blog blog)
        {
            return Ok(_blogService.Update(blog).ToApiModel());
        }

        // DELETE api/blogs/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.Remove(id);
            return Ok();
        }
    }
}
