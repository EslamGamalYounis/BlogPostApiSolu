using BlogPostApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApi.Repositories
{
    public interface ICommentRepository

    {
        List<Comment> getAll();

        Comment getbyid(int id);

        void Add(Comment comment);
        void Edit(Comment comment);
        void Delete(int id);
    }
}
