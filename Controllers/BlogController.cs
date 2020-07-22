using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFabrikam.Models;

namespace MVCFabrikam.Controllers
{
    public class BlogController : Controller
    {

        private FabrikamEntities _context = new FabrikamEntities();

        // GET: Blog
        public ActionResult Blog()
        {
            var obj = new BlogObj();
            return View(obj);
        } 

        public ActionResult AddBlog(BlogObj newBlog)
        {
            var postDB = new Blog()
            {
                Post = newBlog.Post
            };

            _context.Blogs.Add(postDB);

            try
            {
                _context.SaveChanges();
                return View("DisplayBlogs");
            }
            catch(DbUpdateException e)
            {
                return View("Blog");
            }

            
        }

        public ActionResult DisplayBlogs()
        {
            var blogs = new BlogObj();
            blogs.Posts = new List<BlogObj>();

            var query =
                from c in _context.Blogs
                select c;

            foreach (var post in query)
            {
                var postDb = new BlogObj
                {
                    Post = post.Post
                };

                blogs.Posts.Add(postDb);
            }
            
            return View(blogs);
            

        }
    }
}