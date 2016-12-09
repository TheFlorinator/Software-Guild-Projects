using MemeConglomerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeConglomerate.Logic
{
    public class MemeManager
    {
        private IRepository _memeRepo;

        public MemeManager()
        {
            _memeRepo = MemeManagerFactory.Create();
        }

        public List<Meme> GetAllMemes()
        {
            List<Meme> memes = new List<Meme>();
            memes = _memeRepo.GetAll().ToList();
            return memes;
        }

        public List<Meme> SearchMemes(string genre)
        {
            List<Meme> memes = new List<Meme>();
            memes = _memeRepo.Search(genre).ToList();
            return memes;
        }

        public Response<Meme> AddMeme(Meme meme)
        {
            Response<Meme> response = new Response<Meme>();
            if (string.IsNullOrWhiteSpace(meme.Title) || string.IsNullOrWhiteSpace(meme.Description) || string.IsNullOrWhiteSpace(meme.URL))
            {
                response.Success = false;
                response.Message = "All fields must be filled in";
            }
            else
            {
                List<Meme> memes = new List<Meme>();
                memes = _memeRepo.GetAll().ToList();
                meme.Id = memes.Count() + 1;
                _memeRepo.Add(meme);
                response.Success = true;
            }
            return response;
        }

        public Response<Meme> DeleteMeme(int id)
        {
            Response<Meme> response = new Response<Meme>();
            if (id <= 0)
            {
                response.Success = false;
                response.Message = "An error has occurred";
            }
            else
            {
                _memeRepo.Delete(id);
                response.Success = true;
            }
            return response;
        }

        public List<Genre> GetAllGenre()
        {
            List<Genre> genres = new List<Genre>();
            genres = _memeRepo.AllGenres().ToList();
            return genres;
        }
    }
}
