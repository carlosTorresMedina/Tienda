using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace capaPruebas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDatos data = new BaseDatos();
        DataSet tabla=  data.ejecutarConsulta("select * from Vendedor","Vendedor");
            datos.DataSource = tabla;
            datos.DataMember = "Vendedor";
            DataSet tabla2 = data.ejecutarConsulta("Select * from Vendedor", "Vendedor");
            int filas = tabla2.Tables["Vendedor"].Rows.Count;
            if (filas == 0) {
                MessageBox.Show("no hay nada"+filas);
                return;
            }
            MessageBox.Show("prueba 1 : "+tabla2.Tables["Clientes"].Rows[0]["cliNombre"].ToString() );
        }
    }
}
