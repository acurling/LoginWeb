using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginWeb.CapaDatos;
using LoginWeb.CapaLogica;

namespace LoginWeb.CapaVistas
{
    public partial class Articulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            decimal sumatoria = 0;
            int  cant = 0;
            decimal promedio = 0;
           DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM ARTICULOS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dt)
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    int codigo = (int)row["Codigo"];
                    string descripcion = (string)row["Descripcion"];
                    decimal precio = (decimal)row["Precio"];
                    int cantidad = (int)row["Cantidad"];

                    cant++;
                    sumatoria += precio;  // acumulador
                    promedio =  sumatoria /cant;

                }
                Label1.Text = $"cantidad de Articulos {cant} sumatoria de precios {sumatoria} promedio{promedio} ";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
          
            string codigo = txtCodigo.Text;
            string descripcion = txtDescripcion.Text;
            string precio = txtPrecio.Text;
            string cantidad = txtCantidad.Text;

            string lblError = string.Empty;

            if (string.IsNullOrWhiteSpace(codigo))
            {

                lblError = "El código no puede estar vacío.";
               
            } else if (string.IsNullOrWhiteSpace(descripcion))
            {
                lblError= "La descripción no puede estar vacía.";
               
            }
            else if (string.IsNullOrWhiteSpace(precio))
            {
                lblError = "El precio no puede estar vacío.";
                
            }
            else if (string.IsNullOrWhiteSpace(cantidad))
            {
                lblError = "La cantidad no puede estar vacía.";
              
            }

            if (!lblError.Equals(""))
            {
                Clsarticulo.ShowAlert(this, lblError);
            } else if (ClaseArticulo.Agregar(int.Parse(txtCodigo.Text),txtDescripcion.Text,float.Parse(txtPrecio.Text),int.Parse(txtCantidad.Text))>0)
            {
                LlenarGrid();
            } else
            {
                Clsarticulo.ShowAlert(this, lblError);
            }

           
        }

        public void alerts(string mensaje)
        {
            ClientScript.RegisterStartupScript(GetType(), "Advertencia", "<script language='javascript'>alert('" + mensaje + "');</script>");
        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Clsarticulo.ShowAlert(this, " Ha ocurrido un error intente nuevamente");
           
            //// Lógica para borrar un artículo
            //string codigo = txtCodigo.Text;

            //// Aquí puedes agregar la lógica para borrar el artículo de la base de datos
            //Response.Write("Artículo con código " + codigo + " borrado.");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            // Lógica para consultar un artículo
            string codigo = txtCodigo.Text;

            // Aquí puedes agregar la lógica para consultar el artículo en la base de datos
            Response.Write("Consulta del artículo con código " + codigo);
        }
    }
}