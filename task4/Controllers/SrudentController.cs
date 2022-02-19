using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task4.Models.Database;

namespace task4.Controllers
{
    public class SrudentController : Controller
    {
        // GET: Srudent
        public ActionResult Index()
        {
            //db retrival
            studentdbEntities1 db = new studentdbEntities1();
            var data = db.StuTables.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new StuTable());
        }
        [HttpPost]
        public ActionResult Create(StuTable s)
        {
            if(ModelState.IsValid)
            {
                //db insertion
                studentdbEntities1 db = new studentdbEntities1();
                db.StuTables.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Scholarship()
        {
            studentdbEntities1 db = new studentdbEntities1();
            var data1 = (from s in db.StuTables where s.cgpa > 3.75 select s).ToList();
            return View(data1);
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            studentdbEntities1 db = new studentdbEntities1();
            var data2 = (from s in db.StuTables where s.id == Id select s).FirstOrDefault();
            return View(data2);
        }
        [HttpPost]

        public ActionResult Edit(StuTable sub_s)
        {
            studentdbEntities1 db = new studentdbEntities1();
            var data2 = (from s in db.StuTables where s.id == sub_s.id select s).FirstOrDefault();
            db.Entry(data2).CurrentValues.SetValues(sub_s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(StuTable sub_Id)
        {

            studentdbEntities1 db = new studentdbEntities1();
            var data2 = (from s in db.StuTables where s.id == sub_Id.id select s).FirstOrDefault();
            db.StuTables.Remove(data2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}