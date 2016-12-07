using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlogToRestart.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string HashTag { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
