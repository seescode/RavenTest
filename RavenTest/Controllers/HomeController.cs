﻿using Raven.Client.Document;
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
            using (var store = new DocumentStore
            {
                Url = "http://localhost:8451/",
                DefaultDatabase = "Habit"
            }.Initialize())
            {
                using (var session = store.OpenSession())
                {
                    var persons = from i in session.Query<PersonModel>()
                                  //where i.Name == "Sachi"
                                  select i;

                    foreach (var i in persons)
                    {
                        ViewBag.Message += i.Name + ", ";
                    }
                }
            }

            return View();
        }

        public ActionResult CreateDocument()
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
                    var hands = new List<Hand>();
                    hands.Add(new Hand { Position = "left" });
                    hands.Add(new Hand { Position = "right" });

                    session.Store(new PersonModel
                    {
                        Age = 1,
                        Name = "Hikaru",
                        Hands = hands
                    });

                    session.SaveChanges();
                }
            }

            return View();
        }

        public ActionResult ReadDocument(string id)
        {
            if (id == null)
            {
                id = "1";
            }

            using (var store = new DocumentStore
            {
                Url = "http://localhost:8451/",
                DefaultDatabase = "Habit"
            }.Initialize())
            {
                using (var session = store.OpenSession())
                {
                    var person = session.Load<PersonModel>("PersonModels/" + id);
                    ViewBag.Message = person.Name + " " + person.Age;
                }
            }

            return View();
        }

        public ActionResult UpdateDocument(string id)
        {
            if (id == null)
            {
                id = "1";
            }

            using (var store = new DocumentStore
            {
                Url = "http://localhost:8451/",
                DefaultDatabase = "Habit"
            }.Initialize())
            {
                using (var session = store.OpenSession())
                {
                    var person = session.Load<PersonModel>("PersonModels/" + id);

                    person.Name += "1";

                    session.SaveChanges();
                    ViewBag.Message = person.Name + " " + person.Age;
                }
            }

            return View("ReadDocument");
        }

    }
}