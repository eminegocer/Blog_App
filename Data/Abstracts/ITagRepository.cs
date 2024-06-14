using BlogApp.Data.Concreate.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Abstracts
{
    public interface ITagRepository
    {
        IQueryable<Tag>Tags{get;}
        void CreateTag(Tag tag);
    }
}