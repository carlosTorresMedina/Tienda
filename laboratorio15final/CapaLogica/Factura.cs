using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaLogica
{
  public  class Factura
    {

        private BaseDatos data;

        public Factura() {
            this.data = new BaseDatos();
        }

        /**
       registra una factura en el sistema
   **/
        public bool registrarFactura(String vendedor, String cliente, String numero, DateTime fecha, int valorTotal, DataSet datos)
        {
            bool val = data.ejecutarDML("insert into Facturas (facNumero,facFecha,facCliente,facValorTotal,FacVendedor) values('" + numero+ "','" + fecha.Date + "','" + cliente + "'," + valorTotal+ ",'" +vendedor + "')");
            if (val) {
                foreach (DataRow df in datos.Tables["Detalle"].Rows) {
                    String producto = df["facProducto"].ToString();
                    String cantidad = df["facCantidad"].ToString();
                   
                    val = data.ejecutarDML("insert into FacturaDetalle (facNumero,facProducto,facCantidad) values('" + numero + "','" + producto+ "'," + cantidad+ ")");
                }
            }
            return val;
            
       
        }
    }
}
