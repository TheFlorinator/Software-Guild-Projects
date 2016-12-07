using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlogToRestart.Models
{
    public interface IRepository : IDisposable
    {
        bool DoesExsist(int blogId);
        void Delete(int id);
        void Save(Post post);
        Post GetOne(int id);
        Post GetRecent();
        IEnumerable<Post> Search(string hashtag);
        IEnumerable<Post> GetFive();
        IEnumerable<Tag> GetAllTags();
        void SaveTag(Tag tag);
        IEnumerable<Post> GetUnpublishedPosts();
        IEnumerable<Post> GetPublishedPosts();
        IEnumerable<Post> GetTen();


        

    }
}
