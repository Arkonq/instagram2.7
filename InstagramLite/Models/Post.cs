using System;
using Microsoft.AspNetCore.Identity;

namespace InstagramLite.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public int Likes { get; set; }
    }
}