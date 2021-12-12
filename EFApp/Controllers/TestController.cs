using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFApp.Controllers
{
    public class TestController : Controller
    {
        UstDbContexts ust = new UstDbContexts();

        // GET: Test
        public ActionResult Biodata()
        {
            // the below given query is meant for retriving data from biodata tables
            var students = (from std in ust.Biodatas select std).ToList();
            return View(students);
        }

        public ActionResult AddNewStd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewStd(Biodata b)
        {
            if (ModelState.IsValid)
            {               
                ust.Biodatas.Add(b);
                ust.SaveChanges(); // will execute adding data action on database
                                   // (It will generate Insert command)
                ViewBag.info = "Row Added....";
            }
            return View();
        }

        public ActionResult ShowOneStd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowOneStd(Biodata b)
        {
            int rno = b.rollno;
            var students = (from std in ust.Biodatas where std.rollno==rno select std).FirstOrDefault<Biodata>();
            if (students == null)
            {
                ViewBag.info = "No";
                return View();
            }
            ViewBag.info = "Y";
            return View(students);
        }
    }
}