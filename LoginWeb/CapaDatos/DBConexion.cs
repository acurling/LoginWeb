using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginWeb.CapaDatos
{
    public class DBConexion
    {

        public static SqlConnection obtenerConexion()
        {
            string rutaconexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(rutaconexion);
            conexion.Open();
            return conexion;
        }

        public static SqlConnection obtenerConexionuh()
        {
            string rutaconexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexionuh"].ConnectionString;
            SqlConnection conexion = new SqlConnection(rutaconexion);
            conexion.Open();
            return conexion;
        }
    }
}