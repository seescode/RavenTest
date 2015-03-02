using Raven.Client.Document;
using RavenTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RavenTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Creating Document";

            using (var store = new DocumentStore
            {
                Url = "http://localhost:8451/",
                DefaultDatabase = "Habit"
            }.Initialize())
            {
                using (var session = store.OpenSession())
                {
                    session.Store(new PersonModel
                    {
                        Age = 1,
                        Name = "Hikaru"
                    });

                    session.SaveChanges();
                }
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}