using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fBlockBuster.Models;

namespace fBlockBuster.Controllers
{
    public class tblRatingsController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblRatings
        public ActionResult Index()
        {
            return View(db.tblRating.SqlQuery("Select * from tblRating"));
        }

        // GET: tblRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRating tblRating = db.tblRating.Find(id);
            if (tblRating == null)
            {
                return HttpNotFound();
            }
            return View(tblRating);
        }

        // GET: tblRatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblRatings/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRating,Rating")] tblRating tblRating)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT into tblRating VALUES (@Rating)",

                new SqlParameter("Rating", tblRating.Rating)
                );
                return RedirectToAction("Index");
            }

            return View(tblRating);
        }

        // GET: tblRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRating tblRating = db.tblRating.Find(id);
            if (tblRating == null)
            {
                return HttpNotFound();
            }
            return View(tblRating);
        }

        // POST: tblRatings/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRating,Rating")] tblRating tblRating)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblRating " +
                    "SET  Rating = @Rating " +
                    "Where idRating =@idRating",

               new SqlParameter("idRating", tblRating.idRating),
               new SqlParameter("Rating", tblRating.Rating)
               );
                return RedirectToAction("Index");
            }
            return View(tblRating);
        }

        // GET: tblRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRating tblRating = db.tblRating.Find(id);
            if (tblRating == null)
            {
                return HttpNotFound();
            }
            return View(tblRating);
        }

        // POST: tblRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRating tblRating = db.tblRating.Find(id);
            db.Database.ExecuteSqlCommand("DELETE FROM tblRating WHERE idRating = @idRating",
               new SqlParameter("idRating", tblRating.idRating)
               );
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
