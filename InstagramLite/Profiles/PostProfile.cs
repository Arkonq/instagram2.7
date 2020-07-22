using AutoMapper;
using InstagramLite.Models;
using InstagramLite.ViewModels;

namespace InstagramLite.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostViewModel, Post>();
            CreateMap<DbPost, PostViewModel>();
            CreateMap<PostViewModel, DbPost>();
        }
    }
}