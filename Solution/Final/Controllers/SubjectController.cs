using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class SubjectController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Subject/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Subject/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Subject/Create

        [HttpPost]
        public ActionResult Create(Models.SubjectModel subject)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Subject/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Subject/Edit/5

        [HttpPost]
        public ActionResult Edit(Models.SubjectModel subject)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Subject/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Subject/Delete/5

        [HttpPost]
        public ActionResult Delete(Models.SubjectModel subject)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}