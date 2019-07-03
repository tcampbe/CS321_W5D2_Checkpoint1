using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: api/values
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _blogService.GetAll();
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            return _blogService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Blog blog)
        {
            _blogService.Add(blog);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Blog blog)
        {
            _blogService.Update(blog);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _blogService.Remove(id);
        }
    }
}
