using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SQL_API.Models;

namespace SQL_API.Controllers
{
    public class UsersController : Controller
    {
        private DavidKopalaEntities db = new DavidKopalaEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.UsersFblas.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersFbla usersFbla = db.UsersFblas.Find(id);
            if (usersFbla == null)
            {
                return HttpNotFound();
            }
            return View(usersFbla);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstName,lastName,username,password")] UsersFbla usersFbla)
        {
            if (ModelState.IsValid)
            {
                db.UsersFblas.Add(usersFbla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usersFbla);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersFbla usersFbla = db.UsersFblas.Find(id);
            if (usersFbla == null)
            {
                return HttpNotFound();
            }
            return View(usersFbla);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstName,lastName,username,password")] UsersFbla usersFbla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersFbla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersFbla);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersFbla usersFbla = db.UsersFblas.Find(id);
            if (usersFbla == null)
            {
                return HttpNotFound();
            }
            return View(usersFbla);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersFbla usersFbla = db.UsersFblas.Find(id);
            db.UsersFblas.Remove(usersFbla);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
