using System;
using System.IO;
using System.Linq;
using AutoMapper;
using InstagramLite.Infrastructure;
using InstagramLite.Models;
using InstagramLite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;

namespace InstagramLite.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Random _random;
        private readonly IWebHostEnvironment _environment;

        public PostsController(IUnitOfWork uow, IMapper mapper, UserManager<IdentityUser> userManager, 
            Random random, IWebHostEnvironment environment)
        {
            _uow = uow;
            _mapper = mapper;
            _userManager = userManager;
            _random = random;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var posts = _uow.Posts.GetAll().OrderByDescending(x => x.CreatedDate);

            return View(posts);
        }
        public IActionResult Index2()
        {
            var posts = _uow.DbPosts.GetAll().OrderByDescending(x => x.CreatedDate);

            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Post>(viewModel);
                model.CreatedDate = DateTime.Now;

                //var photoId = _random.Next(1, 1000);

                //model.Photo = $"https://picsum.photos/id/{photoId}/300/200";
                model.UserId = _userManager.GetUserId(HttpContext.User);
                model.Likes = 0;

                if (viewModel.Photo != null)
                {
                    var path = "/Files/" + viewModel.Photo.FileName;

                    using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                    {
                        viewModel.Photo.CopyTo(fileStream);
                    }

                    model.Photo = path;
                }

                var createdPost = _uow.Posts.Create(model);
                _uow.Save();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }


        public IActionResult CreateDbPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDbPost(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                DbPost model = new DbPost();
                model.Description = viewModel.Description;
                model.CreatedDate = DateTime.Now;
                model.UserId = _userManager.GetUserId(HttpContext.User);
                model.Likes = 0;

                if (viewModel.Photo != null)
                {
                    byte[] image;

                    using (var binaryReader = new BinaryReader(viewModel.Photo.OpenReadStream()))
                    {
                        image = binaryReader.ReadBytes((int)viewModel.Photo.Length);
                    }

                    model.Photo = image;
                }

                var createdPost = _uow.DbPosts.Create(model);
                _uow.Save();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }




        [HttpPost]
        public JsonResult Like(int postId)
        {
            var post = _uow.Posts.Get(postId);
            post.Likes += 1;

            _uow.Save();

            return Json(new {post.Likes});
        }
    }
}