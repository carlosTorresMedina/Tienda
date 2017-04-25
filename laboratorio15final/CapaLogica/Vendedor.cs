using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogica
{
    public class Vendedor

    {
        public bool iniciarSesion(String nombreVendedor, String contra) {
            BaseDatos data = new BaseDatos();
            DataSet datos = data.ejecutarConsulta("select * from Vendedor where venUsuario='" + nombreVendedor + "' and venContrasena='" + contra + "'","Vendedor");
            int filas = datos.Tables["Vendedor"].Rows.Count;
            if (filas == 0) {
                return false;
            }
            return true;
        }
    }
}
