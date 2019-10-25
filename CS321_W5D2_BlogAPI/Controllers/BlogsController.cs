﻿using System;
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

        // TODO: inject BlogService
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/blogs
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // TODO: code below with the correct implementation
                // to return all blogs
                
                return Ok(_blogService.GetAll()
                    .ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetBlog", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/blogs/{id}
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // TODO: code below with the correct implementation
                // to return a blog by id
                
                return Ok(_blogService.Get(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetBlogs", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/blogs
        [HttpPost]
        public IActionResult Post([FromBody]Blog blog)
        {
            try
            {
                return Ok(_blogService.Add(blog).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddBlog", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/blogs/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Blog blog)
        {
            try
            {
                return Ok(_blogService.Update(blog).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateBlog", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/blogs/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _blogService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteBlog", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
