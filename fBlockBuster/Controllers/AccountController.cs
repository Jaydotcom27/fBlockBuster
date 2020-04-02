using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fBlockBuster.Models;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace fBlockBuster.Controllers
{
    public class AccountController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source =JAYDESK; database=BlockBusterDB; integrated security = SSPI;";

        }

        [HttpPost]

        public ActionResult Verify(Account acc)
        {
            string ConnectionString = "Integrated Security = True; " +
           "Initial Catalog= BlockBusterDB; " + " Data source = JAYDESK; ";
            string SQL = "select * from tblUsuario where NombreUsuario='" + acc.Name + "' and PasswordUsuario='" + acc.Password + "'";

            SqlConnection conn = new SqlConnection(ConnectionString);

            // Create a command object
            SqlCommand cmd = new SqlCommand(SQL, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                bool isAdmin = false;
                int Tipo = Convert.ToInt32(reader.GetSqlInt32(reader.GetOrdinal("idTipo")).Value);
                if (Tipo == 1)
                {
                    isAdmin = true;
                }

                int iduser = Convert.ToInt32(reader.GetSqlInt32(reader.GetOrdinal("idUsuario")).Value);
                Session["usuarioSes"] = iduser;


                if (isAdmin)
                {
                    con.Close();
                    Session["Tipo"] = Tipo;
                    return View($"~/Views/Home/Index.cshtml");
                }
                else
                {
                    con.Close();
                    Session["Tipo"] = Tipo;
                    return View($"~/Views/Home/Index.cshtml");
                   }
            }
            else
            {
                con.Close();
                return View("Error");

            }

        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult aCreate(Account acc)
        {
            connectionString();
            com.CommandText = "INSERT into tblUsuario (NombreUsuario, PasswordUsuario, idTipo) VALUES ('" + acc.Name + "', '" + acc.Password + "', '2')";
            com.Connection = con;
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return View($"~/Views/Home/Index.cshtml");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}