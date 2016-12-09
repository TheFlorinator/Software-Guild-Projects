using MemeConglomerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeConglomerate.Model
{
    public class Meme
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public Genre Genre { get; set; }

    }
}
