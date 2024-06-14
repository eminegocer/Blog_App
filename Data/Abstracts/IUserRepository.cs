using BlogApp.Entity;

namespace BlogApp.Data.Abstracts
{
    public interface IUserRapository
    {
        IQueryable<User>Users {get;}  // Queryable=> listenin bir versiyonu, context üzerinden bütün commetnler alınınca filtreleme yapar.veritabanından filtrelenerek gelir

        void CreateUser(User User);
    }
}