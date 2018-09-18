using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var post = new BlogPost();
            //post.Body = "This is the body";
            //post.Created = DateTime.Now;
            //post.Published = true;
            //post.Title = "This is the title";
            var context = ApplicationDbContext.Create();
            //context.Posts.Add(post);
            //context.SaveChanges();
            var post = context.Posts.Where(p => p.Id == 1).First();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}