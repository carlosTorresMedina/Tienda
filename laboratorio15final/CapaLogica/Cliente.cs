using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogica
{
    class Cliente
    {

        BaseDatos data;

        public Cliente() {
            this.data = new BaseDatos();
        }

        /**
        registra un cliente en el sistema
        **/
        public bool ingresarCliente(String nDocumento, String nombre, String direccion, String telefono, String correo)
        {
            
            bool val = data.ejecutarDML("insert into Clientes (cliDocumento,cliNombre,cliDireccion,cliTelefono,cliCorreo) values('" + nDocumento + "','" + nombre + "','" + direccion + "','" + telefono + "','" + correo + "')");
            return val;
        }

        /**
        consulta todo los clientes registrados en el sistema
        **/
        public DataSet consultarClientes()
        {

            return data.ejecutarConsulta("select * from Clientes","Clientes");
                
        }

        /**
        consulta un cliente en el sistema en base al numero de documento
        **/
        public DataSet consultarClienteEspecifico(String nDocumento)
        {
            return data.ejecutarConsulta("select * from Clientes where cliDocumento= '"+nDocumento+"'", "Clientes");
        }

        /**
       actualiza un determinado cliente en base al numero de documento
       **/
        public bool actualizarCliente(String nDocumentoAuxiliar,String nDocumento, String nombre, String direccion, String telefono, String correo)
        {
            return data.ejecutarDML("update Clientes set cliDocumento='"+nDocumento+"',cliNombre='"+nombre+"',cliDireccion='"+direccion+"',cliTelefono='"+telefono+"',cliCorreo='"+correo+"' where cliDocumento='"+nDocumentoAuxiliar+"'");
        }

        /**
        elimina un determinado cliente en base al numero de documento
    **/
        public bool eliminarCliente(String nDocumento)
        {
            return data.ejecutarDML("delete from Clientes where cliDocumento='"+nDocumento+"'");
        }

    }
}
