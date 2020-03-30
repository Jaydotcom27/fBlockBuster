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
    public class tblTiposController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblTipos
        public ActionResult Index()
        {
            return View(db.tblTipo.SqlQuery("Select * from TblTipo"));
        }

        // GET: tblTipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipo tblTipo = db.tblTipo.Find(id);
            if (tblTipo == null)
            {
                return HttpNotFound();
            }
            return View(tblTipo);
        }

        // GET: tblTipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblTipos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipo,Descripcion,TipoTipo")] tblTipo tblTipo)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT into tblTipo VALUES(@Descripcion,@TipoTipo)",
                    new SqlParameter("Descripcion", tblTipo.Descripcion),
                    new SqlParameter("TipoTipo", tblTipo.TipoTipo)
                    );
                return RedirectToAction("Index");
            }

            return View(tblTipo);
        }

        // GET: tblTipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipo tblTipo = db.tblTipo.Find(id);
            if (tblTipo == null)
            {
                return HttpNotFound();
            }
            return View(tblTipo);
        }

        // POST: tblTipos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipo,Descripcion,TipoTipo")] tblTipo tblTipo)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblTipo " +
                    "set TipoTipo = @TipoTipo, " +
                    "Descripcion = @Descripcion " +
                    "where idTipo = @idTipo",

                new SqlParameter("TipoTipo", tblTipo.TipoTipo),
                new SqlParameter("Descripcion", tblTipo.Descripcion),
                new SqlParameter("idTipo", tblTipo.idTipo)

                );

                return RedirectToAction("Index");
            }
            return View(tblTipo);
        }

        // GET: tblTipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipo tblTipo = db.tblTipo.Find(id);
            if (tblTipo == null)
            {
                return HttpNotFound();
            }
            return View(tblTipo);
        }

        // POST: tblTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTipo tblTipo = db.tblTipo.Find(id);
            db.Database.ExecuteSqlCommand("DELETE from tblTipo " +
                "where idTipo =@idTipo",

                new SqlParameter("idTipo", tblTipo.idTipo)
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
