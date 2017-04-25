using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogica
{
   public class Producto
    {
      private  BaseDatos data;

        public Producto() {
            this.data = new BaseDatos();
        }

        /**
       ingresa un producto al sistema
   **/
        public bool ingresarProducto(String codigo, String descripcion, float valor, int cantidad)
        {

            bool val = data.ejecutarDML("insert into Productos (proCodigo,proDescripcion,proValor,proCantidad) values('" + codigo + "','" + descripcion + "'," + valor + "," + cantidad + ")");
            return val;
        }

        /**
       consulta los productos de forma general
   **/
        public DataSet consultarProductos()
        {
            DataSet datos = this.data.ejecutarConsulta("select * from Productos", "Productos");
            return datos;
        }


        /**
        consulta un producto determinado en base al codigo
    **/
        public DataSet consultarProductoEspecifico(String codigo)
        {
            DataSet datos = this.data.ejecutarConsulta("select * from Productos where proCodigo='"+codigo+"'", "Productos");
            return datos;
        }

        /**
    actualiza un determinado producto en base al codigo
    **/
        public bool actualizarProducto(String codigoA, String codigo, String descripcion, float valor, int cantidad)
        {
            return data.ejecutarDML("update Productos set proCodigo='" + codigo + "',proDescripcion='" + descripcion + "',proValor=" + valor + ",proCantidad=" + cantidad+ " where proCodigo='" + codigoA + "'");

        }

        /**
        elimina un determinado producto en base al codigo
    **/
        public bool eliminarProducto(String codigo)
        {
            return data.ejecutarDML("delete from Productos where proCodigo='" + codigo + "'");
        }
    }
}
