using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using System.Data.SqlClient;

namespace MyWeb.Controllers
{
    public class UserController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        private void connectionString()
        {
            con.ConnectionString = @"Data Source=LAPTOP-CMICOPQI\SQLEXPRESS;Initial Catalog=Account;Integrated Security=True";
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAction(User us)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from USERLOGIN where name = '" + us.username + "' and password = '" + us.password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Index", "Student");
            }
            else
            {
                con.Close();
                return RedirectToAction("Login", "User");
            }
        }
    }
}