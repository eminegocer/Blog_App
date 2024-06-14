using BlogApp.Data.Abstracts;
using BlogApp.Data.Concreate.EfCore;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class NewPosts :ViewComponent
    {
        private IPostRepository _postRepository;

        public NewPosts(IPostRepository postRepository)
        {
            _postRepository =postRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _postRepository   // eklenen posstlardan tarihe göre son 5 tanesini alır
                                .Posts
                                .OrderByDescending(p => p.PublishedOn)
                                .Take(5)
                                .ToListAsync()
                                );
        }
    }
}