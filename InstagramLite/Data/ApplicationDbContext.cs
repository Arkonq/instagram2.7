using System;
using System.Collections.Generic;
using System.Text;
using InstagramLite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstagramLite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<DbPost> DbPosts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
