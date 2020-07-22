using System.Collections;
using System.Collections.Generic;
using InstagramLite.Models;

namespace InstagramLite.Infrastructure
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; set; }
        IDbPostRepository DbPosts { get; set; }

        int Save();
    }
}