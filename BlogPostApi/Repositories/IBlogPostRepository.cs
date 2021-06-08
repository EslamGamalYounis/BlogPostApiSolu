using BlogPostApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApi.Repositories
{
    public interface IBlogPostRepository

    {
        List<BlogPost> getAll();

        BlogPost getbyid(int id);

        void Add(BlogPost post);
        void Edit(BlogPost post);
        void Delete(int id);
    }
}
