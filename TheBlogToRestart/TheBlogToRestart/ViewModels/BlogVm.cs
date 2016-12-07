using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBlogToRestart.Models;

namespace TheBlogToRestart
{
    public class BlogVm
    {
        public Post Post { get; set; }
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
    }
}