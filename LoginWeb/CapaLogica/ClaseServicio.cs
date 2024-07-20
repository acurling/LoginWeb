using LoginWeb.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginWeb.CapaLogica
{
    public class ClaseServicio
    {

        public static int AgregarServicio(string nombre, int plazo, string moneda, decimal monto)
        {
            // variable retorno para validar la ejecucion del proceso 
            int retorno = 0;

            Clsservicios.descripcion = nombre;
            Clsservicios.plazo = plazo;
            Clsservicios.moneda = moneda;
            Clsservicios.monto = monto;

            string query = "INSERT INTO servicios (descripcion, plazo, moneda, monto) VALUES (@Descripcion, @Plazo, @Moneda, @Monto)";
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConexion.obtenerConexionuh())
                {
                    SqlCommand cmd = new SqlCommand(query, Conn);

                    cmd.Parameters.Add(new SqlParameter("@Descripcion", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Plazo", plazo));
                    cmd.Parameters.Add(new SqlParameter("@Moneda", moneda));
                    cmd.Parameters.Add(new SqlParameter("@Monto", monto));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }


        public static int BorrarServicio(int codigo)
        {
            // variable retorno para validar la ejecucion del proceso 
            int retorno = 0;


            string query = "delete servicios where id = @codigo";
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConexion.obtenerConexionuh())
                {
                    SqlCommand cmd = new SqlCommand(query, Conn);

                    cmd.Parameters.Add(new SqlParameter("@codigo", codigo));
      
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}