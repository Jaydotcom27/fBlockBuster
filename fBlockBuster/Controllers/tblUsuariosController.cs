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
    public class tblUsuariosController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblUsuarios
        public ActionResult Index()
        {
            var tblUsuario = db.tblUsuario.Include(t => t.tblTipo);
            return View(tblUsuario.ToList());
        }

        // GET: tblUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuario);
        }

        // GET: tblUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion");
            return View();
        }

        // POST: tblUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,idTipo,NombreUsuario,Correo,PasswordUsuario,CreadoEn")] tblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT into tblUsuario VALUES(@idTipo,@NombreUsuario,@Correo,@PasswordUsuario,@CreadoEn)",
                    new SqlParameter("idTipo", tblUsuario.idTipo),
                    new SqlParameter("NombreUsuario", tblUsuario.NombreUsuario),
                    new SqlParameter("Correo", tblUsuario.Correo),
                    new SqlParameter("PasswordUsuario", tblUsuario.PasswordUsuario),
                    new SqlParameter("CreadoEn", tblUsuario.CreadoEn)
                    );
                return RedirectToAction("Index");
            }

            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblUsuario.idTipo);
            return View(tblUsuario);
        }

        // GET: tblUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblUsuario.idTipo);
            return View(tblUsuario);
        }

        // POST: tblUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,idTipo,NombreUsuario,Correo,PasswordUsuario,CreadoEn")] tblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblUsuario " +
                    "set NombreUsuario = @NombreUsuario, " +
                    "Correo = @Correo, " +
                    "PasswordUsuario = @PasswordUsuario, " +
                    "CreadoEn = @CreadoEn " +
                    "where idUsuario = @idUsuario",

                new SqlParameter("NombreUsuario", tblUsuario.NombreUsuario),
                new SqlParameter("Correo", tblUsuario.Correo),
                new SqlParameter("PasswordUsuario", tblUsuario.PasswordUsuario),
                new SqlParameter("CreadoEn", tblUsuario.CreadoEn),
                new SqlParameter("idUsuario", tblUsuario.idUsuario)
                );

                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(db.tblTipo, "idTipo", "Descripcion", tblUsuario.idTipo);
            return View(tblUsuario);
        }

        // GET: tblUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuario);
        }

        // POST: tblUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            db.Database.ExecuteSqlCommand("DELETE from tblUsuario " +
                "where idUsuario =@idUsuario",

                new SqlParameter("idUsuario", tblUsuario.idUsuario)
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
