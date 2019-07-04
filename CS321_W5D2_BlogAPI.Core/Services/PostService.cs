using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IUserService _userService;

        public PostService(IPostRepository postRepository, IBlogRepository blogRepository, IUserService userService)
        {
            _postRepository = postRepository;
            _blogRepository = blogRepository;
            _userService = userService;
        }

        public Post Add(Post newPost)
        {
            EnsureBlogBelongsToUser(newPost.BlogId);
            newPost.DatePublished = DateTime.Now;
            return _postRepository.Add(newPost);
        }

        public Post Get(int id)
        {
            return _postRepository.Get(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }
        
        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _postRepository.GetBlogPosts(blogId);
        }

        public void Remove(int id)
        {
            var post = this.Get(id);
            EnsureBlogBelongsToUser(post.BlogId);
            _postRepository.Remove(id);
        }

        public Post Update(Post updatedPost)
        {
            EnsureBlogBelongsToUser(updatedPost.BlogId);
            return _postRepository.Update(updatedPost);
        }

        private void EnsureBlogBelongsToUser(int blogId)
        {
            if (!_blogRepository.DoesBlogBelongToUser(blogId, _userService.CurrentUserId))
            {
                throw new ApplicationException("You can only modify blogs that belong to you.");
            }
        }
    }
}
