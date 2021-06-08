using BlogPostApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApi.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        BlogPostContext DbContext;
        public BlogPostRepository(BlogPostContext postContext)
        {
            DbContext = postContext;
        }
        public void Add(BlogPost post)
        {
            DbContext.Add(post);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = DbContext.BlogPosts.Find(id);
            DbContext.BlogPosts.Remove(post);
            DbContext.SaveChanges();
        }

        public void Edit(BlogPost post)
        {
            DbContext.Entry(post).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public List<BlogPost> getAll()
        {
            return DbContext.BlogPosts.ToList();
        }

        public BlogPost getbyid(int id)
        {
            return DbContext.BlogPosts.Find(id);
        }
    }
}
