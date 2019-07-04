using System;
using CS321_W5D2_BlogAPI.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CS321_W5D2_BlogAPI.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W5D2_BlogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {

        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        // GET /api/blogs/{blogId}/posts
        [AllowAnonymous]
        [HttpGet("/api/blogs/{blogId}/posts")]
        public IActionResult Get(int blogId)
        {
            var posts = _postService.GetBlogPosts(blogId);
            return Ok(posts.ToApiModels());
        }

        // GET api/blogs/{blogId}/posts/{postId}
        [AllowAnonymous]
        [HttpGet("/api/blogs/{blogId}/posts/{postId}")]
        public IActionResult Get(int blogId, int postId)
        {
            var post = _postService.Get(postId);
            return Ok(post.ToApiModel());
        }

        // POST /api/blogs/{blogId}/post
        [HttpPost("/api/blogs/{blogId}/posts")]
        public IActionResult Post(int blogId, [FromBody]PostModel postModel)
        {
            try
            {
                var newPost = _postService.Add(postModel.ToDomainModel());
                return Ok(newPost);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddPost", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT /api/blogs/{blogId}/posts/{postId}
        [HttpPut("/api/blogs/{blogId}/posts/{postId}")]
        public IActionResult Put(int blogId, int postId, [FromBody]PostModel postModel)
        {
            try
            {
                var updatedPost = _postService.Update(postModel.ToDomainModel());
                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddPost", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("/api/blogs/{blogId}/posts/{postId}")]
        public IActionResult Delete(int blogId, int postId)
        {
            try
            {
                _postService.Remove(postId);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddPost", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
