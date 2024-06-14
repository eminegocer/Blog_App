using BlogApp.Data.Abstracts;
using BlogApp.Entity;

namespace BlogApp.Data.Concreate.EfCore
{
    public class EfTagRepository:ITagRepository
    {  //sınıf oluşturulduktan sonra program.cs içinde  tanıması lazım 
        private BlogContext _context;
        public EfTagRepository(BlogContext context)
        {
            _context=context;
        }

        public IQueryable<Tag> Tags =>_context.Tags;

        public void CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
    }
}