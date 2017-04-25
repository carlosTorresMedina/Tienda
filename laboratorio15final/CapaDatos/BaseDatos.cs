using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BaseDatos
    {

        private string CadenaConexion = "data source=CARLOSTORRES\\SQLEXPRESS;initial catalog=Tienda;integrated security=true";
        private SqlConnection Conexion;




       
        public DataSet ejecutarConsulta(String sql, String nombreTabla)
        {
            try
            {
                this.Conexion = new SqlConnection(this.CadenaConexion);
                DataSet datos = new DataSet();
                SqlDataAdapter miAdaptador = new SqlDataAdapter(sql, Conexion);
                miAdaptador.Fill(datos, nombreTabla);
                this.Conexion.Close();
                return datos;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Conexion.Close();

                return null;
            }
        }

       
        public Boolean ejecutarDML(String DML)
        {
            bool val = false;
            try
            {
                this.Conexion = new SqlConnection(this.CadenaConexion);
                this.Conexion.Open();
                SqlCommand comando = new SqlCommand(DML, Conexion);
                if (comando.ExecuteNonQuery() > 0)
                {
                    val = true;
                }
                Conexion.Close();
                return val;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Conexion.Close();

                return false;
            }

        }

    }



   
}
