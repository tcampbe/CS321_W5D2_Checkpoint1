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
    public class PostsController : Controller
    {
        private static string _content = @"<p>
                            Curabitur cum mollis ullamcorper ridiculus nunc, bibendum cubilia mi quis. Nisl nostra ut iaculis porta iaculis vitae litora natoque? Vitae semper magnis purus cubilia ut. Arcu, nulla porta pretium neque libero pulvinar proin nascetur natoque. Donec eleifend metus himenaeos consectetur nec nulla. Vel est fusce fermentum varius quisque lacinia consequat aliquam dignissim cursus? Congue parturient condimentum accumsan sem, lobortis pellentesque integer. Per egestas odio himenaeos. At fermentum vulputate porttitor cubilia vestibulum phasellus iaculis. Arcu per bibendum nibh aptent dictumst posuere netus rhoncus senectus sociis et. Est?
                            </p>
                            <p>
                            Scelerisque praesent fermentum enim eu risus elementum, imperdiet sociis libero parturient. Primis quisque at per. Nascetur nam elementum natoque viverra vitae purus egestas non cras aenean. Natoque placerat porta justo posuere ornare dapibus nam pulvinar maecenas. Taciti volutpat cubilia proin cum sociis velit congue egestas suscipit cubilia sapien platea. Nunc facilisi turpis suspendisse convallis.
                            </p>
                            <p>
                            Taciti vel at suscipit accumsan mi interdum ipsum tristique. Penatibus blandit placerat a dui eleifend porta gravida eros per dis convallis natoque. Turpis fermentum litora gravida pretium. Eleifend litora sollicitudin pulvinar sagittis, accumsan molestie ridiculus malesuada. Dictumst neque eu consectetur sociis eget, curae; eu ornare.Bibendum, class interdum id eros sagittis nisi ut leo.Duis mollis risus curabitur nulla ridiculus potenti congue ad semper fringilla interdum mollis! Convallis proin aptent, velit arcu gravida.Quisque suscipit vulputate integer? Magnis.
                            </p>";

        private List<Post> _posts = new List<Post> {
            new Post
            {
                Id = 1,
                BlogId = 1,
                Title = "blah blah blah",
                Content = _content,
                 CommentsAllowed = true
            },
            new Post {
                Id = 2,
                BlogId = 1,
                Title = "blah blah blah",
                Content = _content,
                 CommentsAllowed = true
            },
            new Post {
                Id = 3,
                BlogId = 2,
                Title = "blah blah blah",
                Content = _content,
               CommentsAllowed = true
            },
            new Post{
                Id = 4,
                BlogId = 2,
                Title = "blah blah blah",
                Content = _content,
                CommentsAllowed = true
            },
        };
        // GET: api/values
        [AllowAnonymous]
        [HttpGet("/api/blogs/{blogId}/posts")]
        public IActionResult Get(int blogId)
        {
            return Ok(_posts.Where(p => p.BlogId == blogId).ToList());
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("/api/blogs/{blogId}/posts/{postId}")]
        public IActionResult Get(int blogId, int postId)
        {
            return Ok(_posts.SingleOrDefault(p => p.Id == postId));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("/api/blogs/{blogId}/posts/{postId}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
