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
    public class tblTransaccionesController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblTransacciones
        public ActionResult Index()
        {
            var tblTransaccion = db.tblTransaccion./*Include(t => t.tblArticulo).*/Include(t => t.tblEstado).Include(t => t.tblTipo).Include(t => t.tblUsuario);
            return View(db.tblTransaccion.SqlQuery("Select * from tblTransaccion"));

        }

        // GET: tblTransacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransaccion tblTransaccion = db.tblTransaccion.Find(id);
            if (tblTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tblTransaccion);
        }

        // GET: tblTransacciones/Create
        public ActionResult Create()
        {
            //ViewBag.idArticulo = new SelectList(db.tblArticulo, "idArticulo", "Miniatura");
            ViewBag.idEstado = new SelectList(db.tblEstado, "idEstado", "Estado");
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion");
            ViewBag.idUsuario = new SelectList(db.tblUsuario, "idUsuario", "NombreUsuario");
            return View();
        }

        // POST: tblTransacciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTransaccion,idTipo,idEstado,idUsuario,Precio,Fecha")] tblTransaccion tblTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT into tblTransaccion VALUES(@idTipo,@idEstado,@idUsuario,@Precio,@Fecha)",
                    new SqlParameter("idTipo", tblTransaccion.idTipo),
                    new SqlParameter("idEstado", tblTransaccion.idEstado),
                    new SqlParameter("idUsuario", tblTransaccion.idUsuario),
                    //new SqlParameter("idArticulo", tblTransaccion.idArticulo),
                    new SqlParameter("Precio", tblTransaccion.Precio),
                    new SqlParameter("Fecha", tblTransaccion.Fecha)
                    );
                return RedirectToAction("Index");
            }

            //ViewBag.idArticulo = new SelectList(db.tblArticulo, "idArticulo", "Miniatura", tblTransaccion.idArticulo);
            ViewBag.idEstado = new SelectList(db.tblEstado, "idEstado", "Estado", tblTransaccion.idEstado);
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblTransaccion.idTipo);
            ViewBag.idUsuario = new SelectList(db.tblUsuario, "idUsuario", "NombreUsuario", tblTransaccion.idUsuario);
            return View(tblTransaccion);
        }

        // GET: tblTransacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransaccion tblTransaccion = db.tblTransaccion.Find(id);
            if (tblTransaccion == null)
            {
                return HttpNotFound();
            }
            //ViewBag.idArticulo = new SelectList(db.tblArticulo, "idArticulo", "Miniatura", tblTransaccion.idArticulo);
            ViewBag.idEstado = new SelectList(db.tblEstado, "idEstado", "Estado", tblTransaccion.idEstado);
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblTransaccion.idTipo);
            ViewBag.idUsuario = new SelectList(db.tblUsuario, "idUsuario", "NombreUsuario", tblTransaccion.idUsuario);
            return View(tblTransaccion);
        }

        // POST: tblTransacciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransaccion,idTipo,idEstado,idUsuario,Precio,Fecha")] tblTransaccion tblTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblTransaccion " +
                    "set idTipo = @idTipo, " +
                    "idEstado = @idEstado, " +
                    "idUsuario = @idUsuario, " +
                    //"idArticulo = @idArticulo, " +
                    "Precio = @Precio, " +
                    "Fecha = @Fecha " +
                    "where idTransaccion = @idTransaccion",

                new SqlParameter("idTransaccion", tblTransaccion.idTransaccion),
                new SqlParameter("idTipo", tblTransaccion.idTipo),
                new SqlParameter("idEstado", tblTransaccion.idEstado),
                new SqlParameter("idUsuario", tblTransaccion.idUsuario),
                //new SqlParameter("idArticulo", tblTransaccion.idArticulo),
                new SqlParameter("Precio", tblTransaccion.Precio),
                new SqlParameter("Fecha", tblTransaccion.Fecha)

                );

                return RedirectToAction("Index");
            }
            //ViewBag.idArticulo = new SelectList(db.tblArticulo, "idArticulo", "Miniatura", tblTransaccion.idArticulo);
            ViewBag.idEstado = new SelectList(db.tblEstado, "idEstado", "Estado", tblTransaccion.idEstado);
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblTransaccion.idTipo);
            ViewBag.idUsuario = new SelectList(db.tblUsuario, "idUsuario", "NombreUsuario", tblTransaccion.idUsuario);
            return View(tblTransaccion);
        }

        // GET: tblTransacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransaccion tblTransaccion = db.tblTransaccion.Find(id);
            if (tblTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tblTransaccion);
        }

        // POST: tblTransacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTransaccion tblTransaccion = db.tblTransaccion.Find(id);
            db.Database.ExecuteSqlCommand("DELETE from tblTransaccion " +
                "where idTransaccion =@idTransaccion",
                new SqlParameter("idTransaccion", tblTransaccion.idTransaccion)
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
