using System.Collections.Generic;
using System.Linq;
using InstagramLite.Data;
using InstagramLite.Models;
using Microsoft.EntityFrameworkCore;

namespace InstagramLite.Infrastructure
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Post Create(Post post)
        {
            var entry = _context.Posts.Add(post);
            return entry.Entity;
        }

        public IList<Post> GetAll()
        {
            return _context.Posts.Include(x => x.User).ToList();
        }

        public Post Get(int id)
        {
            return _context.Posts.Find(id);
        }
    }
}