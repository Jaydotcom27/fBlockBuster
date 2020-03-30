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
    public class tblArticulosController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblArticulos
        public ActionResult Index()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(tblArticulo.ToList());
        }

        // GET: tblArticulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticulo tblArticulo = db.tblArticulo.Find(id);
            if (tblArticulo == null)
            {
                return HttpNotFound();
            }
            return View(tblArticulo);
        }

        // GET: tblArticulos/Create
        public ActionResult Create()
        {
            ViewBag.idArticuloDetalle = new SelectList(db.tblArticuloDetalle, "idArticuloDetalle", "Productor");
            ViewBag.idGenero = new SelectList(db.tblGenero, "idGenero", "Genero");
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion");
            return View();
        }

        // POST: tblArticulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArticulo,idArticuloDetalle,idTipo,idGenero,Miniatura,Nombre,Descripcion,Duracion,Temporadas,Episodios")] tblArticulo tblArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO tblArticulo VALUES(@idArticuloDetalle,@idTipo,@idGenero,@Miniatura,@Nombre,@Descripcion,@Duracion,@Temporadas,@Episodios)",
                    new SqlParameter("idArticuloDetalle", tblArticulo.idArticuloDetalle),
                    new SqlParameter("idTipo", tblArticulo.idTipo),
                    new SqlParameter("idGenero", tblArticulo.idGenero),
                    new SqlParameter("Miniatura", tblArticulo.Miniatura),
                    new SqlParameter("Nombre", tblArticulo.Nombre),
                    new SqlParameter("Descripcion", tblArticulo.Descripcion),
                    new SqlParameter("Duracion", tblArticulo.Duracion),
                    new SqlParameter("Temporadas", tblArticulo.Temporadas),
                    new SqlParameter("Episodios", tblArticulo.Episodios)
                    );
                return RedirectToAction("Index");
            }

            ViewBag.idArticuloDetalle = new SelectList(db.tblArticuloDetalle, "idArticuloDetalle", "Productor", tblArticulo.idArticuloDetalle);
            ViewBag.idGenero = new SelectList(db.tblGenero, "idGenero", "Genero", tblArticulo.idGenero);
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblArticulo.idTipo);
            return View(tblArticulo);
        }

        // GET: tblArticulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticulo tblArticulo = db.tblArticulo.Find(id);
            if (tblArticulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticuloDetalle = new SelectList(db.tblArticuloDetalle, "idArticuloDetalle", "Productor", tblArticulo.idArticuloDetalle);
            ViewBag.idGenero = new SelectList(db.tblGenero, "idGenero", "Genero", tblArticulo.idGenero);
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblArticulo.idTipo);
            return View(tblArticulo);
        }

        // POST: tblArticulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArticulo,idArticuloDetalle,idTipo,idGenero,Miniatura,Nombre,Descripcion,Duracion,Temporadas,Episodios")] tblArticulo tblArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblArticulo SET idTipo = @idTipo, idGenero = @idGenero, Miniatura = @Miniatura, " +
                    "Nombre = @Nombre,Descripcion = @Descripcion, Duracion = @Duracion,@Temporadas, Episodios = @Episodios WHERE idArticulo = @idArticulo",
                    new SqlParameter("idTipo", tblArticulo.idTipo),
                    new SqlParameter("idGenero", tblArticulo.idGenero),
                    new SqlParameter("Miniatura", tblArticulo.Miniatura),
                    new SqlParameter("Nombre", tblArticulo.Nombre),
                    new SqlParameter("Descripcion", tblArticulo.Descripcion),
                    new SqlParameter("Duracion", tblArticulo.Duracion),
                    new SqlParameter("Temporadas", tblArticulo.Temporadas),
                    new SqlParameter("Episodios", tblArticulo.Episodios),
                    new SqlParameter("idArticulo", tblArticulo.idArticulo)
                    );
                return RedirectToAction("Index");
            }

            ViewBag.idArticuloDetalle = new SelectList(db.tblArticuloDetalle, "idArticuloDetalle", "Productor", tblArticulo.idArticuloDetalle);
            ViewBag.idGenero = new SelectList(db.tblGenero, "idGenero", "Genero", tblArticulo.idGenero);
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblArticulo.idTipo);
            return View(tblArticulo);
        }

        // GET: tblArticulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticulo tblArticulo = db.tblArticulo.Find(id);
            if (tblArticulo == null)
            {
                return HttpNotFound();
            }
            return View(tblArticulo);
        }

        // POST: tblArticulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblArticulo tblArticulo = db.tblArticulo.Find(id);
            db.Database.ExecuteSqlCommand("DELETE FROM tblArticulo WHERE idArticulo = @idArticulo",
                new SqlParameter("idArticulo", tblArticulo.idArticulo)
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
