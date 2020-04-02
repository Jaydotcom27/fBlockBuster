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
    public class tblArticuloDetallesController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblArticuloDetalles
        public ActionResult Index()
        {
            var tblArticuloDetalle = db.tblArticuloDetalle.Include(t => t.tblRating);
            return View(db.tblArticuloDetalle.SqlQuery("SELECT * from tblArticuloDetalle")); 
        }

        // GET: tblArticuloDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticuloDetalle tblArticuloDetalle = db.tblArticuloDetalle.Find(id);
            if (tblArticuloDetalle == null)
            {
                return HttpNotFound();
            }
            return View(tblArticuloDetalle);
        }

        // GET: tblArticuloDetalles/Create
        public ActionResult Create()
        {
            ViewBag.idRating = new SelectList(db.tblRating, "idRating", "Rating");
            return View();
        }

        // POST: tblArticuloDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArticuloDetalle,idRating,Productor,Director,Estudio,Formato,Idioma,Subtitulos,Nota,Año")] tblArticuloDetalle tblArticuloDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO tblArticuloDetalle VALUES(@idRating,@Productor,@Director,@Estudio,@Formato,@Idioma,@Subtitulos,@Nota, @Año)",
                    new SqlParameter("idRating", tblArticuloDetalle.idRating),
                    new SqlParameter("Productor", tblArticuloDetalle.Productor),
                    new SqlParameter("Director", tblArticuloDetalle.Director),
                    new SqlParameter("Estudio", tblArticuloDetalle.Estudio),
                    new SqlParameter("Formato", tblArticuloDetalle.Formato),
                    new SqlParameter("Idioma", tblArticuloDetalle.Idioma),
                    new SqlParameter("Subtitulos", tblArticuloDetalle.Subtitulos),
                    new SqlParameter("Nota", tblArticuloDetalle.Nota),
                    new SqlParameter("Año", tblArticuloDetalle.Año)
                    );
                return RedirectToAction("Index");
            }

            ViewBag.idRating = new SelectList(db.tblRating, "idRating", "Rating", tblArticuloDetalle.idRating);
            return View(tblArticuloDetalle);
        }

        // GET: tblArticuloDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticuloDetalle tblArticuloDetalle = db.tblArticuloDetalle.Find(id);
            if (tblArticuloDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRating = new SelectList(db.tblRating, "idRating", "Rating", tblArticuloDetalle.idRating);
            return View(tblArticuloDetalle);
        }

        // POST: tblArticuloDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArticuloDetalle,idRating,Productor,Director,Estudio,Formato,Idioma,Subtitulos,Nota,Año")] tblArticuloDetalle tblArticuloDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblArticuloDetalle SET idRating = @idRating, Productor = @Productor, Director = @Director, Estudio = @Estudio, " +
                    "Formato = @Formato, Idioma = @Idioma, Subtitulos = @Subtitulos, Nota = @Nota, Año = @Año WHERE idArticuloDetalle = @idArticuloDetalle",
                    new SqlParameter("idRating", tblArticuloDetalle.idRating),
                    new SqlParameter("Productor", tblArticuloDetalle.Productor),
                    new SqlParameter("Director", tblArticuloDetalle.Director),
                    new SqlParameter("Estudio", tblArticuloDetalle.Estudio),
                    new SqlParameter("Formato", tblArticuloDetalle.Formato),
                    new SqlParameter("Idioma", tblArticuloDetalle.Idioma),
                    new SqlParameter("Subtitulos", tblArticuloDetalle.Subtitulos),
                    new SqlParameter("Nota", tblArticuloDetalle.Nota),
                    new SqlParameter("Año", tblArticuloDetalle.Año),
                    new SqlParameter("idArticuloDetalle", tblArticuloDetalle.idArticuloDetalle)
                    );
                return RedirectToAction("Index");
            }
            ViewBag.idRating = new SelectList(db.tblRating, "idRating", "Rating", tblArticuloDetalle.idRating);
            return View(tblArticuloDetalle);
        }

        // GET: tblArticuloDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticuloDetalle tblArticuloDetalle = db.tblArticuloDetalle.Find(id);
            if (tblArticuloDetalle == null)
            {
                return HttpNotFound();
            }
            return View(tblArticuloDetalle);
        }

        // POST: tblArticuloDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblArticuloDetalle tblArticuloDetalle = db.tblArticuloDetalle.Find(id);
            db.Database.ExecuteSqlCommand("DELETE FROM tblArticulo WHERE idArticuloDetalle = @idArticuloDetalle",
                new SqlParameter("idArticuloDetalle", tblArticuloDetalle.idArticuloDetalle)
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
