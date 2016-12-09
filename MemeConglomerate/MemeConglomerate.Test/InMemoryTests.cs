using MemeConglomerate.Logic;
using MemeConglomerate.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeConglomerate.Test
{
    [TestFixture]
    public class InMemoryTests
    {
        [Test]
        public void CanGetAllMemes()
        {
            MemeManager manager = new MemeManager();
            var allMemes = manager.GetAllMemes();
            Assert.AreEqual(8, allMemes.Count());
        }

        [TestCase("A title", "SomeURL", "A Description", "A cool genre", true)]
        [TestCase("", "SomeURL", "A Description", "A cool genre", false)]
        [TestCase("A title", "", "A Description", "A cool genre", false)]
        [TestCase("A title", "SomeURL", "", "A cool genre", false)]
        public void CanAddMeme(string title, string image, string description, string genre, bool expectedResults)
        {
            MemeManager manager = new MemeManager();
            Meme meme = new Meme
            {
                Title = title,
                URL = image,
                Description = description,
                Genre = new Genre() { Name = genre}
            };
            var response = manager.AddMeme(meme);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase(1, true)]
        [TestCase(3, true)]
        [TestCase(-5, false)]
        public void CanDeleteMeme(int id, bool expectedResults)
        {
            MemeManager manager = new MemeManager();
            var response = manager.DeleteMeme(id);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase("Ron Swanson", 2)]
        [TestCase("Work", 2)]
        [TestCase("Cats", 2)]
        public void CanSearchByGenre(string name, int expectedCount)
        {
            MemeManager manager = new MemeManager();
            var response = manager.SearchMemes(name);
            Assert.AreEqual(expectedCount, response.Count());
        }
    }
}
