using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;

namespace LoginWeb.CapaDatos
{
    public class Clsarticulo
    {
        public static int codigo { get; set; }
        public static string desripcion { get; set; }
        public static float precio { get; set; }
        public static int cantidad { get; set; }

        public static void ShowAlert(Page page, string message)
    {
        string script = $"<script type='text/javascript'>alert('{message}');</script>";
        ClientScriptManager cs = page.ClientScript;
        cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
    }



    }
}