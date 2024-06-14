using BlogApp.Data.Concreate.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.ViewComponents
{
    // veriyi veritabanından alır 
    public class TagsMenu:ViewComponent
    {
        private BlogContext _tagRepository;
        public TagsMenu(BlogContext tagRepository)
        {
            _tagRepository=tagRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _tagRepository.Tags.ToListAsync());
        }
    }
}