using MemeConglomerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeConglomerate.Data
{
    public class InMemory : IRepository
    {
        private static List<Meme> _memes;
        static InMemory()
        {
            _memes = new List<Meme>();
            var memeOne = new Meme()
            {
                Id = 1,
                Title = "All things Steak!",
                Description = "Ron Swanson being Ron Swanson, ordering courses all of which are steak!",
                URL = "https://cdn.pastemagazine.com/www/system/images/photo_albums/ron-swanson-memes/large/memes-rs-5-course-dinner.jpg?1384968217",
                Genre = new Genre() { Id = 1, Name = "Ron Swanson" },
            };

            var memeTwo = new Meme()
            {
                Id = 2,
                Title = "It's FRIDAY!!!",
                Description = "What it feels like to leave work on Friday",
                URL = "http://i.qkme.me/6v24.jpg",  
                Genre = new Genre() { Id = 3, Name = "Work" },
            };

            var memeThree = new Meme()
            {
                Id = 3,
                Title = "Grumpy Cat!",
                Description = "Grumpy cat being grumpy cat...",
                URL = "http://www.inboundmarketingagents.com/hs-fs/hub/160334/file-18160199-jpg/images/grumpy-cat-meme-01.jpg?t=1477923159664&width=250&height=250&name=grumpy-cat-meme-01.jpg",
                Genre = new Genre() { Id = 2, Name = "Cats" },
            };
            
            var memeFour = new Meme()
            {
                Id = 4,
                Title = "All things Steak!",
                Description = "Ron Swanson being Ron Swanson, ordering courses all of which are steak!",
                URL = "https://cdn.pastemagazine.com/www/system/images/photo_albums/ron-swanson-memes/large/memes-rs-5-course-dinner.jpg?1384968217",
                Genre = new Genre() { Id = 1, Name = "Ron Swanson" },
            };

            var memeFive = new Meme()
            {
                Id = 5,
                Title = "Leaving Work!",
                Description = "What it feels like to leave work on Friday",
                URL = "http://i.qkme.me/6v24.jpg",
                Genre = new Genre() { Id = 3, Name = "Work" },
            };

            var memeSix = new Meme()
            {
                Id = 6,
                Title = "Safety!",
                Description = "How to stay safe while lounging",
                URL = "https://www.askideas.com/media/48/Cat-Funny-Safety-Meme-Picture.jpg",
                Genre = new Genre() { Id = 2, Name = "Cats" },
            };
            _memes.Add(memeOne);
            _memes.Add(memeTwo);
            _memes.Add(memeThree);
            _memes.Add(memeFour);
            _memes.Add(memeFive);
            _memes.Add(memeSix);
        }
        public void Add(Meme meme)
        {
            _memes.Add(meme);
        }

        public void Delete(int id)
        {
            _memes.RemoveAll(i => i.Id == id);
        }

        public IEnumerable<Meme> GetAll()
        {
            return _memes;
        }

        public IEnumerable<Meme> Search(string genre)
        {
            List<Meme> memes = new List<Meme>();
            foreach (var meme in _memes)
            {
                if (meme.Genre.Name == genre)
                {
                    memes.Add(meme);
                }
            }
            return memes;
        }

        public IEnumerable<Genre> AllGenres()
        {
            List<Genre> genres = new List<Genre>();
            foreach (var meme in _memes)
            {
                //for testing purposes
                if (meme.Genre != null)
                {
                    if (!genres.Any(i => i.Id == meme.Genre.Id))
                    {
                        genres.Add(meme.Genre);
                    }
                }
                
            }
            return genres;
        }
    }
}
