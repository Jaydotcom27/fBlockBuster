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
    public class tblArticuloTransaccionesController : Controller
    {
        private BlockBusterDBEntities db = new BlockBusterDBEntities();

        // GET: tblArticuloTransacciones
        public ActionResult Index()
        {
            var tblArticuloTransaccion = db.tblArticuloTransaccion.Include(t => t.tblArticulo).Include(t => t.tblTransaccion);
            return View(db.tblArticuloTransaccion.SqlQuery("Select * from tblArticuloTransaccion"));

        }

        public ActionResult Carrito()
        {
            var tblArticuloTransaccion = db.tblArticuloTransaccion.Include(t => t.tblArticulo).Include(t => t.tblTransaccion);
            int sidUsuario = Convert.ToInt32(Session["usuarioSes"]);

            string ConnectionString = "Integrated Security = True; " +
            "Initial Catalog= BlockBusterDB; " + " Data source = JAYDESK; ";
            string SQL = "  Select sum(tblArticulo.Precio) as sumPrecios " +
                "from tblArticulo " +
                "inner join tblArticuloTransaccion on tblArticuloTransaccion.idArticulo = tblArticulo.idArticulo " +
                "inner join tblTransaccion on tblArticuloTransaccion.idTransaccion = tblTransaccion.idTransaccion where idUsuario = '" + sidUsuario + "' and tblTransaccion.idEstado = 1; ";

            SqlConnection conn = new SqlConnection(ConnectionString);

            // Create a command object
            SqlCommand cmd = new SqlCommand(SQL, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                try
                {
                    decimal sumPrecio = (reader[0]) != System.DBNull.Value ? Convert.ToDecimal(reader[0]) : 0;
                    ViewBag.PrecioSumado = sumPrecio;
                }
                catch (Exception)
                {

                }
            }
            return View(db.tblArticuloTransaccion.SqlQuery("Select * from tblArticuloTransaccion " +
                "inner join tblTransaccion on tblArticuloTransaccion.idTransaccion = tblTransaccion.idTransaccion where idUsuario = '"+sidUsuario+"' and idEstado = 1;"));
        }

        public ActionResult Confirmar()
        {
            var tblArticuloTransaccion = db.tblArticuloTransaccion.Include(t => t.tblArticulo).Include(t => t.tblTransaccion);
            int sidUsuario = Convert.ToInt32(Session["usuarioSes"]);
            decimal sumPrecio = 0;

            string ConnectionString = "Integrated Security = True; " +
            "Initial Catalog= BlockBusterDB; " + " Data source = JAYDESK; ";
            string SQL = "  Select sum(tblArticulo.Precio) as sumPrecios " +
                "from tblArticulo " +
                "inner join tblArticuloTransaccion on tblArticuloTransaccion.idArticulo = tblArticulo.idArticulo " +
                "inner join tblTransaccion on tblArticuloTransaccion.idTransaccion = tblTransaccion.idTransaccion where idUsuario = '" + sidUsuario + "' and tblTransaccion.idEstado = 1; ";

            SqlConnection conn = new SqlConnection(ConnectionString);

            // Create a command object
            SqlCommand cmd = new SqlCommand(SQL, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                sumPrecio = (reader[0]) != System.DBNull.Value ? Convert.ToDecimal(reader[0]) : 0;
                ViewBag.PrecioSumado = sumPrecio;

            }

            db.Database.ExecuteSqlCommand("UPDATE tblTransaccion " +
                "set idEstado = 2, " +
                "Precio = @Precio " +
                "where idUsuario = @idUsuario and idEstado = 1",

            new SqlParameter("Precio", sumPrecio),
            new SqlParameter("idUsuario", sidUsuario)
            );
            return View($"~/Views/Home/Index.cshtml"); //-----------------Compra Exitosa Here
        }

        // GET: tblArticuloTransacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticuloTransaccion tblArticuloTransaccion = db.tblArticuloTransaccion.Find(id);
            if (tblArticuloTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tblArticuloTransaccion);
        }

        // GET: tblArticuloTransacciones/Create
        public ActionResult Create()
        {
            ViewBag.idArticulo = new SelectList(db.tblArticulo, "idArticulo", "Miniatura");
            ViewBag.idTransaccion = new SelectList(db.tblTransaccion, "idTransaccion", "idTransaccion");
            return View();
        }

        // POST: tblArticuloTransacciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArticuloTransaccion,idArticulo,idTransaccion")] tblArticuloTransaccion tblArticuloTransaccion)
        {
            //if (ModelState.IsValid)
            //{
            //    db.tblArticuloTransaccion.Add(tblArticuloTransaccion);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT into tblArticuloTransaccion VALUES(@idArticulo,@idTransaccion)",
                    new SqlParameter("idArticulo", tblArticuloTransaccion.idArticulo),
                    new SqlParameter("idTransaccion", tblArticuloTransaccion.idTransaccion)
                    );
                return RedirectToAction("Index");
            }
            ViewBag.idArticulo = new SelectList(db.tblArticulo, "idArticulo", "Miniatura", tblArticuloTransaccion.idArticulo);
            ViewBag.idTransaccion = new SelectList(db.tblTransaccion, "idTransaccion", "idTransaccion", tblArticuloTransaccion.idTransaccion);
            return View(tblArticuloTransaccion);
        }

        // GET: tblArticuloTransacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticuloTransaccion tblArticuloTransaccion = db.tblArticuloTransaccion.Find(id);
            if (tblArticuloTransaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticulo = new SelectList(db.tblArticulo, "idArticulo", "Miniatura", tblArticuloTransaccion.idArticulo);
            ViewBag.idTransaccion = new SelectList(db.tblTransaccion, "idTransaccion", "idTransaccion", tblArticuloTransaccion.idTransaccion);
            return View(tblArticuloTransaccion);
        }

        // POST: tblArticuloTransacciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArticuloTransaccion,idArticulo,idTransaccion")] tblArticuloTransaccion tblArticuloTransaccion)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tblArticuloTransaccion).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblArticuloTransaccion " +
                    "set idArticulo = @idArticulo, " +
                    "idTransaccion = @idTransaccion " +
                    "where idArticuloTransaccion = @idArticuloTransaccion",

                new SqlParameter("idArticulo", tblArticuloTransaccion.idArticulo),
                new SqlParameter("idTransaccion", tblArticuloTransaccion.idTransaccion),
               new SqlParameter("idArticuloTransaccion", tblArticuloTransaccion.idArticuloTransaccion)


                );

                return RedirectToAction("Index");
            }

            ViewBag.idArticulo = new SelectList(db.tblArticulo, "idArticulo", "Miniatura", tblArticuloTransaccion.idArticulo);
            ViewBag.idTransaccion = new SelectList(db.tblTransaccion, "idTransaccion", "idTransaccion", tblArticuloTransaccion.idTransaccion);
            return View(tblArticuloTransaccion);
        }

        // GET: tblArticuloTransacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArticuloTransaccion tblArticuloTransaccion = db.tblArticuloTransaccion.Find(id);
            if (tblArticuloTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tblArticuloTransaccion);
        }

        // POST: tblArticuloTransacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblArticuloTransaccion tblArticuloTransaccion = db.tblArticuloTransaccion.Find(id);
            //db.tblArticuloTransaccion.Remove(tblArticuloTransaccion);
            //db.SaveChanges();

            tblTipo tblTipo = db.tblTipo.Find(id);
            db.Database.ExecuteSqlCommand("DELETE from tblArticuloTransaccion " +
                "where idArticuloTransaccion =@idArticuloTransaccion",

                new SqlParameter("idArticuloTransaccion", tblArticuloTransaccion.idArticuloTransaccion)
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
