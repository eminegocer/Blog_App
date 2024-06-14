using BlogApp.Entity;

namespace BlogApp.Data.Abstracts
{
    public interface IPostRepository
    {
        IQueryable<Post>Posts {get;}  // Queryable=> listenin bir versiyonu, context üzerinden bütün postlar alınınca filtreleme yapar.veritabanından filtrelenerek gelir

        void CreatePost(Post post);
        void EditPost(Post post);
        void EditPost(Post post, int [] tagIds);

        
    }
}