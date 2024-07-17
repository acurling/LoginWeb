using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace LoginWeb.CapaDatos
{
    public class Clsusuario
    {
        public static int codigo { get; set; }
        public static string correo { get; set; }
        public static string clave { get; set; }
        public static string  nombre { get; set; }
    }
}