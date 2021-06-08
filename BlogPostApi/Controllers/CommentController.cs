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
    public class CommentController: ControllerBase
    {
        public ICommentRepository commentRepository{ get; set; }
        public CommentController(ICommentRepository _commentRepository)
        {
            commentRepository = _commentRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(commentRepository.getAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetById(int id)
        {
            var comment = commentRepository.getbyid(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpPost("{Comment}")]
        public ActionResult Add(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            commentRepository.Add(comment);
            return Content("added successfully");
        }

        [HttpPut("{Comment}/{id}")]
        public ActionResult Edit(Comment comment, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != comment.CommentId)
            {
                return BadRequest(ModelState);
            }

            commentRepository.Edit(comment);
            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult Delete(int id)
        {
            try
            {
                commentRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
