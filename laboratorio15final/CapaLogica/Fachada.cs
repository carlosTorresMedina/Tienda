using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaLogica
{
    public class Fachada
    {
        /**
        inicia session en el sistema
        **/
        public bool iniciarSesion(String nombre, String contra)
        {
            Vendedor v = new Vendedor();
            return v.iniciarSesion(nombre, contra);
        }

        /**
        ingresa clientes en el sistema
        **/
        public bool ingresarCliente(String nDocumento,String nombre,String direccion,String telefono,String correo)
        {
            Cliente c = new Cliente();
            return c.ingresarCliente(nDocumento, nombre, direccion, telefono, correo);
        }

        /**
        consulta todos los clientes registrados en el sistema
        **/
        public DataSet consultarClientes() {
            Cliente c = new Cliente();
            return c.consultarClientes();
        }

        /**
        consulta un cliente en el sistema en base al numero de documento
        **/
        public DataSet consultarClienteEspecifico(String nDocumento) {
            Cliente c = new Cliente();
            return c.consultarClienteEspecifico(nDocumento);
        }

        /**
        actualiza un determinado cliente en base al numero de documento
        **/
        public bool actualizarCliente(String nDocumentoAuxiliar, String nDocumento, String nombre, String direccion, String telefono, String correo) {
             Cliente c=new Cliente();
            return c.actualizarCliente(nDocumentoAuxiliar,nDocumento,nombre,direccion,telefono,correo);

        }

        /**
        elimina un determinado cliente en base al numero de documento
    **/
        public bool eliminarCliente(String nDocumento) {
            Cliente c = new Cliente();
            return c.eliminarCliente(nDocumento);
        }


        /**
        ingresa un producto al sistema
    **/
        public bool ingresarProducto(String codigo,String descripcion,float valor,int cantidad) {
            Producto p = new Producto();
            return p.ingresarProducto(codigo,descripcion,valor,cantidad);
           
        }


        /**
        consulta los productos de forma general
    **/
        public DataSet consultarProductos() {

            Producto p = new Producto();
            return p.consultarProductos();
        }


        /**
        consulta un producto determinado en base al codigo
    **/
        public DataSet consultarProductoEspecifico(String codigo) {
            Producto p = new Producto();
            return p.consultarProductoEspecifico(codigo);
        }

        /**
      actualiza un determinado producto en base al codigo
      **/
        public bool actualizarProducto(String codigoA, String codigo, String descripcion, float valor, int cantidad)
        {
            Producto p = new Producto();
            return p.actualizarProducto(codigoA,codigo,descripcion,valor,cantidad);

        }

        /**
        elimina un determinado producto en base al codigo
    **/
        public bool eliminarProducto(String codigo)
        {
            Producto p = new Producto();
            return p.eliminarProducto(codigo);
        }


        /**
        registra una factura en el sistema
    **/
        public bool registrarFactura(String vendedor, String cliente,String numero, DateTime fecha,int valorTotal, DataSet datos) {
            Factura f = new Factura();

            return f.registrarFactura(vendedor,cliente,numero,fecha,valorTotal,datos);
        }
    }
}
