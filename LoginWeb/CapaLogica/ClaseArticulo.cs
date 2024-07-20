using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using LoginWeb.CapaDatos;
using LoginWeb.CapaVistas;

namespace LoginWeb.CapaLogica
{
    public class ClaseArticulo
    {


        public static int Agregar(int codigo, string nombre, float precio, int cantidad)
        {
            int retorno =0;
            Clsarticulo.codigo = codigo;
            Clsarticulo.cantidad = cantidad;
            Clsarticulo.precio = precio;
            Clsarticulo.desripcion = nombre;

            string query = "INSERT INTO articulos (codigo, descripcion, precio, cantidad) VALUES (@Codigo, @Descripcion, @Precio, @Cantidad)";
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, Conn);
                   
                    cmd.Parameters.Add(new SqlParameter("@Codigo", codigo));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Precio", precio));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", cantidad));
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