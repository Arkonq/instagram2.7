using System.Collections;
using System.Collections.Generic;
using InstagramLite.Models;

namespace InstagramLite.Infrastructure
{
    public interface IPostRepository
    {
        Post Create(Post post);

        IList<Post> GetAll();

        Post Get(int id);
    }
}