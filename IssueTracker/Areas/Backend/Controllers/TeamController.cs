using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class TeamController : Controller
    {
        // GET: Backend/Team
        public ActionResult Index()
        {
            return View();
        }

        // GET: Backend/Team/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Backend/Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Backend/Team/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Backend/Team/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Backend/Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Backend/Team/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Backend/Team/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
