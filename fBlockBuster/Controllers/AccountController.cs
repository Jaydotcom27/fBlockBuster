﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fBlockBuster.Models;
using System.Data.SqlClient;

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
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tblUsuario where NombreUsuario='" +acc.Name+"' and PasswordUsuario='"+acc.Password+"'" ;
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}