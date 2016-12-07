using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TheBlogToRestart.Models
{
    public class Post
    {
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Your title must be longer!")]
        public string Title { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "An image link must be provided")]
        public string Image { get; set; }
        [Required(ErrorMessage = "An address must be provided")]
        public string Address { get; set; }
        [Required(ErrorMessage = "An author must be provided")]
        public string Author { get; set; }
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Your description must be longer!")]
        public string Description { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 300, ErrorMessage = "Your content must be longer!")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Content { get; set; }       
        public bool Published { get; set; }
        public int PostId { get; set; }
        [Required(ErrorMessage = "Please choose at least one tag!")]
        public virtual List<Tag> Tags { get; set; }
    }

    
}
