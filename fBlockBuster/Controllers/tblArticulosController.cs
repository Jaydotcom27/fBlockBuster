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
            return View(db.tblArticulo.SqlQuery("SELECT * from TblArticulo WHERE idTipo = 3")); //Solo peliculas
        }

        public ActionResult Series()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("SELECT * from TblArticulo WHERE idTipo = 4")); //Solo Series
        }

        public ActionResult sGenero()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("SELECT A.idArticulo, A.idArticuloDetalle, A.idTipo, A.idGenero, A.Miniatura, A.Nombre, A.Descripcion, A.Duracion, A.Temporadas, A.Episodios, A.Precio " +
                "FROM tblGenero AS G INNER JOIN tblArticulo AS A ON G.idGenero = A.idGenero " +
                "INNER JOIN tblArticuloDetalle AS AD ON A.idArticuloDetalle = AD.idArticuloDetalle WHERE idTipo = 3 ORDER BY Genero ASC")); 
        }

        public ActionResult sDuracion()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("SELECT A.idArticulo, A.idArticuloDetalle, A.idTipo, A.idGenero, A.Miniatura, A.Nombre, A.Descripcion, A.Duracion, A.Temporadas, A.Episodios, A.Precio " +
                "FROM tblGenero AS G INNER JOIN tblArticulo AS A ON G.idGenero = A.idGenero INNER JOIN tblArticuloDetalle AS AD ON A.idArticuloDetalle = AD.idArticuloDetalle WHERE idTipo = 3 " +
                "ORDER BY Duracion ASC")); 
        }

        public ActionResult sNombre()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("	SELECT  A.idArticulo, A.idArticuloDetalle, A.idTipo, A.idGenero, A.Miniatura, A.Nombre, A.Descripcion, A.Duracion, A.Temporadas, A.Episodios, A.Precio " +
                "FROM tblGenero AS G INNER JOIN tblArticulo AS A ON G.idGenero = A.idGenero INNER JOIN tblArticuloDetalle AS AD ON A.idArticuloDetalle = AD.idArticuloDetalle " +
                "WHERE idTipo = 3 ORDER BY Nombre ASC"));
        }

        public ActionResult sPrecio()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("	SELECT  A.idArticulo, A.idArticuloDetalle, A.idTipo, A.idGenero, A.Miniatura, A.Nombre, A.Descripcion, A.Duracion, A.Temporadas, A.Episodios, A.Precio " +
                "FROM tblGenero AS G INNER JOIN tblArticulo AS A ON G.idGenero = A.idGenero INNER JOIN tblArticuloDetalle AS AD ON A.idArticuloDetalle = AD.idArticuloDetalle " +
                "WHERE idTipo = 3 ORDER BY Precio ASC"));
        }

        public ActionResult Genero()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("SELECT A.idArticulo, A.idArticuloDetalle, A.idTipo, A.idGenero, A.Miniatura, A.Nombre, A.Descripcion, A.Duracion, A.Temporadas, A.Episodios, A.Precio " +
                "FROM tblGenero AS G INNER JOIN tblArticulo AS A ON G.idGenero = A.idGenero " +
                "INNER JOIN tblArticuloDetalle AS AD ON A.idArticuloDetalle = AD.idArticuloDetalle WHERE idTipo = 4 ORDER BY Genero ASC"));
        }

        public ActionResult Duracion()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("SELECT A.idArticulo, A.idArticuloDetalle, A.idTipo, A.idGenero, A.Miniatura, A.Nombre, A.Descripcion, A.Duracion, A.Temporadas, A.Episodios, A.Precio " +
                "FROM tblGenero AS G INNER JOIN tblArticulo AS A ON G.idGenero = A.idGenero INNER JOIN tblArticuloDetalle AS AD ON A.idArticuloDetalle = AD.idArticuloDetalle WHERE idTipo = 4 " +
                "ORDER BY Duracion ASC"));
        }

        public ActionResult Nombre()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("	SELECT  A.idArticulo, A.idArticuloDetalle, A.idTipo, A.idGenero, A.Miniatura, A.Nombre, A.Descripcion, A.Duracion, A.Temporadas, A.Episodios, A.Precio " +
                "FROM tblGenero AS G INNER JOIN tblArticulo AS A ON G.idGenero = A.idGenero INNER JOIN tblArticuloDetalle AS AD ON A.idArticuloDetalle = AD.idArticuloDetalle " +
                "WHERE idTipo = 4 ORDER BY Nombre ASC"));
        }

        public ActionResult Precio()
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);
            return View(db.tblArticulo.SqlQuery("	SELECT  A.idArticulo, A.idArticuloDetalle, A.idTipo, A.idGenero, A.Miniatura, A.Nombre, A.Descripcion, A.Duracion, A.Temporadas, A.Episodios, A.Precio " +
                "FROM tblGenero AS G INNER JOIN tblArticulo AS A ON G.idGenero = A.idGenero INNER JOIN tblArticuloDetalle AS AD ON A.idArticuloDetalle = AD.idArticuloDetalle " +
                "WHERE idTipo = 4 ORDER BY Precio ASC"));
        }

        public ActionResult Agregar(int? id)
        {
            var tblArticulo = db.tblArticulo.Include(t => t.tblArticuloDetalle).Include(t => t.tblGenero).Include(t => t.tblTipo);

            int sidUsuario = Convert.ToInt32(Session["usuarioSes"]);
            string ConnectionString = "Integrated Security = True; " +
            "Initial Catalog= BlockBusterDB; " + " Data source = JAYDESK; ";
            string SQL = " select * from tblTransaccion where idUsuario = '" + sidUsuario + "'  and idEstado = 1;";

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlConnection conn2 = new SqlConnection(ConnectionString);

            // Create a command object
            SqlCommand cmd = new SqlCommand(SQL, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            bool hasTrans = false;

            if (reader.Read())
            {

                hasTrans = true;
            }
            else
            {
                db.Database.ExecuteSqlCommand("INSERT into tblTransaccion VALUES(@idTipo,@idEstado,@idUsuario,@Precio,@Fecha)",
                    new SqlParameter("idTipo", 5),
                    new SqlParameter("idEstado", 1),
                    new SqlParameter("idUsuario", sidUsuario),
                    new SqlParameter("Precio", "0"),
                    new SqlParameter("Fecha", DateTime.Now)
                    );
            }
            conn.Close();

            SqlCommand cmd2 = new SqlCommand(SQL, conn2);
            conn2.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.Read())
            {
                int transaccionid = Convert.ToInt32(reader2.GetSqlInt32(reader2.GetOrdinal("idTransaccion")).Value);
                db.Database.ExecuteSqlCommand("INSERT into tblArticuloTransaccion VALUES(@idArticulo,@idTransaccion)",
                     new SqlParameter("idArticulo", id),
                     new SqlParameter("idTransaccion", transaccionid)
                     );
            }
            conn2.Close();
            return View($"~/Views/Home/Index.cshtml");
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
        public ActionResult Create([Bind(Include = "idArticulo,idArticuloDetalle,idTipo,idGenero,Miniatura,Nombre,Descripcion,Duracion,Temporadas,Episodios,Precio")] tblArticulo tblArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO tblArticulo VALUES(@idArticuloDetalle,@idTipo,@idGenero,@Miniatura,@Nombre,@Descripcion,@Duracion,@Temporadas,@Episodios,@Precio)",
                    new SqlParameter("idArticuloDetalle", tblArticulo.idArticuloDetalle),
                    new SqlParameter("idTipo", tblArticulo.idTipo),
                    new SqlParameter("idGenero", tblArticulo.idGenero),
                    new SqlParameter("Miniatura", tblArticulo.Miniatura),
                    new SqlParameter("Nombre", tblArticulo.Nombre),
                    new SqlParameter("Descripcion", tblArticulo.Descripcion),
                    new SqlParameter("Duracion", tblArticulo.Duracion),
                    new SqlParameter("Temporadas", tblArticulo.Temporadas),
                    new SqlParameter("Episodios", tblArticulo.Episodios), 
                    new SqlParameter("Precio", tblArticulo.Precio)
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
        public ActionResult Edit([Bind(Include = "idArticulo,idArticuloDetalle,idTipo,idGenero,Miniatura,Nombre,Descripcion,Duracion,Temporadas,Episodios,Precio")] tblArticulo tblArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE tblArticulo " +
                    "SET idTipo = @idTipo, " +
                    "idGenero = @idGenero, " +
                    "Miniatura = @Miniatura, " +
                    "Nombre = @Nombre," +
                    "Descripcion = @Descripcion, " +
                    "Duracion = @Duracion," +
                    "Temporadas = @Temporadas, " +
                    "Episodios = @Episodios, " +
                    "Precio = @Precio " +

                    "WHERE idArticulo = @idArticulo",

                    new SqlParameter("idTipo", tblArticulo.idTipo),
                    new SqlParameter("idGenero", tblArticulo.idGenero),
                    new SqlParameter("Miniatura", tblArticulo.Miniatura),
                    new SqlParameter("Nombre", tblArticulo.Nombre),
                    new SqlParameter("Descripcion", tblArticulo.Descripcion),
                    new SqlParameter("Duracion", tblArticulo.Duracion),
                    new SqlParameter("Temporadas", tblArticulo.Temporadas),
                    new SqlParameter("Episodios", tblArticulo.Episodios),
                    new SqlParameter("idArticulo", tblArticulo.idArticulo),
                    new SqlParameter("Precio", tblArticulo.Precio)

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
