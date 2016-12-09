using MemeConglomerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeConglomerate.Models
{
    public class GenreView
    {
        public List<SelectListItem> SelectedGenres { get; set; }
        public Meme Meme { get; set; }

        public GenreView()
        {
            SelectedGenres = new List<SelectListItem>();
        }

        public void SetGenres(IEnumerable<Genre> genres)
        {
            foreach (var genre in genres)
            {
                SelectedGenres.Add(new SelectListItem()
                {
                    Value = genre.Id.ToString(),
                    Text = genre.Name
                });
            }
        }
    }
}