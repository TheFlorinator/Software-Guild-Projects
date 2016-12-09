using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeConglomerate.Model
{
    public interface IRepository
    {
        IEnumerable<Meme> GetAll();
        IEnumerable<Meme> Search(string genre);
        void Delete(int id);
        void Add(Meme meme);
        IEnumerable<Genre> AllGenres();
    }
}
