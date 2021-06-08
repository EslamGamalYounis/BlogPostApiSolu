using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApi.Models
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
