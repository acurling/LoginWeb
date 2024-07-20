using LoginWeb.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWeb.CapaVistas
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bingresar_Click(object sender, EventArgs e)
        {
            Validarusuario(tusuario.Text, tclave.Text);
        }


        protected void Validarusuario(string email, string clave)
        {
            Clsusuario.correo = email;
            Clsusuario.clave = clave;
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("select email, clave, nombre from usuario where email = '" + email + "' " +
                "and clave = '" + clave + "'", conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                Clsusuario.nombre = registro["nombre"].ToString();
                Response.Redirect("inicio.aspx");
            }
            else
            {
                MensajeJavaScript.ShowAlert(this, "Usuario o contraseña incorrectos, intente de nuevo");
            }
            conexion.Close();

        }
    }
}