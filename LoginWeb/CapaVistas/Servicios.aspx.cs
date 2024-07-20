using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginWeb.CapaLogica;
using LoginWeb.CapaDatos;

namespace LoginWeb.CapaVistas
{
    public partial class Servicios : System.Web.UI.Page
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
          
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["conexionuh"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID, DESCRIPCION, PLAZO, MONEDA, MONTO  FROM SERVICIOS"))
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

              
            }
        }

        protected void Limpiar()
        {
            txtDescripcion.Text = string.Empty;
            txtPlazo.Text = string.Empty;
            txtmoneda.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCodigo.Text = string.Empty;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            string error = "";
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                error = " El campo descripcion no puede quedar en blanco";
            else if (string.IsNullOrWhiteSpace(txtPlazo.Text))
                error = " El campo Plazo no puede quedar en blanco";

            if (error.Equals(""))
            {
              if (ClaseServicio.AgregarServicio(txtDescripcion.Text, int.Parse(txtPlazo.Text), txtmoneda.Text, decimal.Parse(txtPrecio.Text)) > 0)
                {
                    LlenarGrid();
                    Limpiar();
                }
              else 
                {
                    MensajeJavaScript.ShowAlert(this, "Error al ingresar los datos");
                }
              
            } else
            {
                MensajeJavaScript.ShowAlert(this, error);
            }

          
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string error = "";
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                error = " El campo Codigo no puede quedar en blanco";

            if (error.Equals(""))
            {
                if (ClaseServicio.BorrarServicio(int.Parse(txtCodigo.Text)) > 0)
                {
                    LlenarGrid(); // refrescar
                    Limpiar(); 
                }
                else
                {
                    MensajeJavaScript.ShowAlert(this, "Error al borrar el servicio");
                }

            }
            else
            {
                MensajeJavaScript.ShowAlert(this, error);
            }

        }
    }
}