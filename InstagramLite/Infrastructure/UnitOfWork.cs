using System.Collections.Generic;
using InstagramLite.Data;
using InstagramLite.Models;

namespace InstagramLite.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPostRepository Posts { get; set; }
        public IDbPostRepository DbPosts { get; set; }

        public UnitOfWork(ApplicationDbContext context, IPostRepository repository, IDbPostRepository dbPostRepository)
        {
            _context = context;
            Posts = repository;
            DbPosts = dbPostRepository;
        }


        public int Save()
        {
            var result = _context.SaveChanges();
            return result;
        }
    }
}