using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBlogToRestart.Models;

namespace TheBlogToRestart.Logic
{
    public class Rules
    {
        private IRepository _blogRepo;

        public Rules()
        {
            _blogRepo = RulesFactory.Create();
        }


        public Response<List<Post>> GetTopFive()
        {
            Response<List<Post>> response = new Response<List<Post>>();
            using (IRepository repo = RulesFactory.Create())
            {
                response.Post = _blogRepo.GetFive().ToList();
                response.Success = true;
            }
            return response;
        }

        public Response<List<Post>> GetTopTen()
        {
            Response<List<Post>> response = new Response<List<Post>>();
            using (IRepository repo = RulesFactory.Create())
            {
                response.Post = _blogRepo.GetTen().ToList();
                response.Success = true;
            }

                return response;
        }
      
        public Response<Post> GetMostRecent()
        {
            Response<Post> response = new Response<Post>();

            response.Post = _blogRepo.GetRecent();
            return response;
        }

        public Response<Post> GetOnePost(int postId)
        {
            Response<Post> response = new Response<Post>();
            if (postId <= 0)
            {
                response.Success = false;
                response.Message = "An error occurred with the post ID";
            }
            else 
            {
                response.Post = _blogRepo.GetOne(postId);
                if (response.Post == null)
                {
                    response.Success = false;
                    response.Message = "An error has occurred";
                }
                else
                {
                    response.Success = true;
                }
            }
            return response;
        }

        public Response<List<Post>> SearchByHashTag(string hashtag)
        {
            Response<List<Post>> response = new Response<List<Post>>();
            if (string.IsNullOrEmpty(hashtag))
            {
                response.Success = false;
                response.Message = "Tag name cannot be empty";
            }
            else
            {
                response.Post = _blogRepo.Search(hashtag).ToList();
                if (response.Post.Count == 0)
                {
                    response.Success = false;
                    response.Message = "An error has occurred";
                }
                else
                {
                    response.Success = true;
                }
            }
            return response;
        }

        public Response<Post> AddPost(Post post)
        {
            Response<Post> response = new Response<Post>();
            if (string.IsNullOrWhiteSpace(post.Content) || post.Tags.Count <= 0)
            {
                response.Success = false;
                response.Message = "Content must be provided, and tags must be provided";
            }
            else if (string.IsNullOrWhiteSpace(post.Author) || string.IsNullOrWhiteSpace(post.Title) || string.IsNullOrWhiteSpace(post.Description))
            {
                response.Success = false;

                response.Message = "An author must be provided";
            }
          
            else
            {
                DateTime date = DateTime.Today;
                post.PostDate = date;
                _blogRepo.Save(post);
                if (_blogRepo.DoesExsist(post.PostId))
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                }
                response.Success = true;
            }
            return response;
        }

        public Response<Post> EditPost(Post post)
        {
            Response<Post> response = new Response<Post>();
            if (post.PostId <= 0 || post.Tags.Count <= 0)
            {
                response.Success = false;
                response.Message = "An Error has occurred";
            }
            else if (string.IsNullOrWhiteSpace(post.Author) || string.IsNullOrWhiteSpace(post.Content) || string.IsNullOrWhiteSpace(post.Description) || string.IsNullOrWhiteSpace(post.Title))
            {
                response.Success = false;

                response.Message = "Content must be provided";
            }
           
            else
            {
                _blogRepo.Save(post);
                response.Success = true;
            }
            return response;
        }

        public Response<Post> DeletePost(int id)
        {
            Response<Post> reponse = new Response<Post>();
            if (id <= 0)
            {
                reponse.Success = false;
                reponse.Message = "Invalid Id";
            }
            else
            {
                _blogRepo.Delete(id);
                if (!_blogRepo.DoesExsist(id))
                {
                    reponse.Success = true;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = "An error has occurred";
                }
            }
            return reponse;
        }

        public List<Tag> GetAllTags()
        {
            List<Tag> tags = new List<Tag>();
            tags = _blogRepo.GetAllTags().ToList();
            return tags;
        }

        public Response<Tag> SaveTag(Tag tag)
        {
            Response<Tag> response = new Response<Tag>();
            if (string.IsNullOrWhiteSpace(tag.HashTag))
            {
                response.Success = false;
                response.Message = "An erorr has occurred";
            }
            else
            {
                _blogRepo.SaveTag(tag);
                response.Success = true;
            }
            return response;
        }

        public Response<List<Post>> GetAllPublishedPosts()
        {
            Response<List<Post>> response = new Response<List<Post>>();
            response.Post = _blogRepo.GetPublishedPosts().ToList();
            return response;
        }

        public Response<List<Post>> GetUnpublishedPosts()
        {
            Response<List<Post>> response = new Response<List<Post>>();
            response.Post = _blogRepo.GetUnpublishedPosts().ToList();
            return response;
        }


        public Response<List<Post>> GetAboutUsPosts()
        {
            Response<List<Post>> response = new Response<List<Post>>();
            response.Post = new List<Post>();
            var aboutUs = _blogRepo.GetPublishedPosts().ToList();
            foreach (var cont in aboutUs)
            {
                if (cont.Title.StartsWith("About:"))
                {
                    response.Post.Add(cont);
                }
            }

            return response;
        }

    }
}
