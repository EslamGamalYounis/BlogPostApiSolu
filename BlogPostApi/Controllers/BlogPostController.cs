using BlogPostApi.Models;
using BlogPostApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        public IBlogPostRepository  BlogPostRepo{ get; set; }
        public BlogPostController(IBlogPostRepository _blogPostRepository)
        {
            BlogPostRepo = _blogPostRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(BlogPostRepo.getAll()); 
        }

        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetById(int id)
        {
            var post = BlogPostRepo.getbyid(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpPost("{BlogPost}")]
        public ActionResult Add(BlogPost post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BlogPostRepo.Add(post);
            return Content("added successfully");
        }

        [HttpPut("{BlogPost}/{id}")]
        public ActionResult Edit(BlogPost post,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != post.BlogPostId)
            {
                return BadRequest(ModelState);
            }

            BlogPostRepo.Edit(post);
            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult Delete(int id)
        {
            try
            {
                BlogPostRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
