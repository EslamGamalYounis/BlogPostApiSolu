using BlogPostApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApi.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        BlogPostContext DbContext;
        public CommentRepository(BlogPostContext postContext)
        {
            DbContext = postContext;
        }
        public void Add(Comment comment)
        {
            DbContext.Comments.Add(comment);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment= DbContext.Comments.Find(id);
            DbContext.Comments.Remove(comment);
            DbContext.SaveChanges();
        }

        public void Edit(Comment comment)
        {
            DbContext.Entry(comment).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public List<Comment> getAll()
        {
            return DbContext.Comments.ToList();
        }

        public Comment getbyid(int id)
        {
            return DbContext.Comments.Find(id);
        }
    }
}
