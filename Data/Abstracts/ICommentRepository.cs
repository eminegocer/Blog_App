using BlogApp.Entity;

namespace BlogApp.Data.Abstracts
{
    public interface ICommentRapository
    {
        IQueryable<Comment>Comments {get;}  // Queryable=> listenin bir versiyonu, context üzerinden bütün commetnler alınınca filtreleme yapar.veritabanından filtrelenerek gelir

        void CreateComment(Comment comment);
    }
}