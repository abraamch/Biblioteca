using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;

using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.Controllers
{
    public class AccesoController : Controller
    {

        static string cadena = "Data Source=(RUTH\\SQLEXPRESS);Initial Catalog=Proyecto_PNT1;Integrated Security=true";

        public ActionResult Login()
        {
            return View();
        }



        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(Usuario u)
        {
            Boolean registrado;
            String mensaje;

            if (u.contrasenia != u.ConfirmarClave)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_registraUsuario", cn);
                cmd.Parameters.AddWithValue("Usuario", u.usuario);
                cmd.Parameters.AddWithValue("Contrasenia", u.contrasenia);
                cmd.Parameters.AddWithValue("Nombre", u.nombre);
                cmd.Parameters.AddWithValue("Apellido", u.apellido);
                cmd.Parameters.AddWithValue("Dni", u.dni);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,100).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();


                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                 mensaje = cmd.Parameters["Mensaje"].Value.ToString();

            }
             ViewData["Mensaje"] =mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Accesos");

            }
            else
            {
                return View();
            }

        }
    }
}

