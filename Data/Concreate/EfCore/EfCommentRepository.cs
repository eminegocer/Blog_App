using BlogApp.Data.Abstracts;
using BlogApp.Entity;
using BlogApp.Data.Concreate.EfCore;

namespace BlogApp.Data.Concreate
{
    public class EfCommentRepository : ICommentRapository
    {  //sınıf oluşturulduktan sonra program.cs içinde  tanıması lazım 
        private BlogContext _context;
        public EfCommentRepository(BlogContext context)
        {
            _context=context;
        }

        public IQueryable<Comment> Comments =>_context.Comments;

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }

}