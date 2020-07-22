using Microsoft.AspNetCore.Http;

namespace InstagramLite.ViewModels
{
    public class PostViewModel
    {
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}