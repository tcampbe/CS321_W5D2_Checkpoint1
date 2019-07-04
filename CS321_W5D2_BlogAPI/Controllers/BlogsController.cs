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

        // GET: api/values
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_blogService.GetAll().ToApiModels());
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_blogService.Get(id).ToApiModel());
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Blog blog)
        {
            return Ok(_blogService.Add(blog).ToApiModel());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Blog blog)
        {
            return Ok(_blogService.Update(blog).ToApiModel());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.Remove(id);
            return Ok();
        }
    }
}
