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
    public class tblEstadosController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblEstados
        public ActionResult Index()
        {
            return View(db.tblEstado.ToList());
        }

        // GET: tblEstados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstado tblEstado = db.tblEstado.Find(id);
            if (tblEstado == null)
            {
                return HttpNotFound();
            }
            return View(tblEstado);
        }

        // GET: tblEstados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEstados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstado,Estado")] tblEstado tblEstado)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT into tblEstado VALUES (@Estado)",
                new SqlParameter("Estado", tblEstado.Estado)
                );
                return RedirectToAction("Index");
            }

            return View(tblEstado);
        }

        // GET: tblEstados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstado tblEstado = db.tblEstado.Find(id);
            if (tblEstado == null)
            {
                return HttpNotFound();
            }
            return View(tblEstado);
        }

        // POST: tblEstados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstado,Estado")] tblEstado tblEstado)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblEstado SET  idEstado=@idEstado, Estado = @Estado",
                    new SqlParameter("idEstado", tblEstado.idEstado),
                    new SqlParameter("Estado", tblEstado.Estado)
                    );
                return RedirectToAction("Index");
            }
            return View(tblEstado);
        }

        // GET: tblEstados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstado tblEstado = db.tblEstado.Find(id);
            if (tblEstado == null)
            {
                return HttpNotFound();
            }
            return View(tblEstado);
        }

        // POST: tblEstados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEstado tblEstado = db.tblEstado.Find(id);
            db.Database.ExecuteSqlCommand("DELETE FROM tblEstado WHERE idEstado = @idEstado",
                new SqlParameter("idEstado", tblEstado.idEstado)
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
