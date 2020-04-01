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
    public class tblGenerosController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblGeneros
        public ActionResult Index()
        {
            return View(db.tblGenero.ToList());
        }

        // GET: tblGeneros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGenero tblGenero = db.tblGenero.Find(id);
            if (tblGenero == null)
            {
                return HttpNotFound();
            }
            return View(tblGenero);
        }

        // GET: tblGeneros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblGeneros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idGenero,Genero")] tblGenero tblGenero)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT into tblGenero VALUES (@Genero)",

                new SqlParameter("Genero", tblGenero.Genero)
                );
                return RedirectToAction("Index");
            }

            return View(tblGenero);
        }

        // GET: tblGeneros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGenero tblGenero = db.tblGenero.Find(id);
            if (tblGenero == null)
            {
                return HttpNotFound();
            }
            return View(tblGenero);
        }

        // POST: tblGeneros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idGenero,Genero")] tblGenero tblGenero)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblEstado SET  idGenero = @idGenero, Genero = @Genero",
                    new SqlParameter("idGenero", tblGenero.idGenero),
                    new SqlParameter("Genero", tblGenero.Genero)
                    );
                return RedirectToAction("Index");
            }
            return View(tblGenero);
        }

        // GET: tblGeneros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGenero tblGenero = db.tblGenero.Find(id);
            if (tblGenero == null)
            {
                return HttpNotFound();
            }
            return View(tblGenero);
        }

        // POST: tblGeneros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGenero tblGenero = db.tblGenero.Find(id);
            db.Database.ExecuteSqlCommand("DELETE FROM tblArticulo WHERE idGenero = @idGenero",
                new SqlParameter("idGenero", tblGenero.idGenero)
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
