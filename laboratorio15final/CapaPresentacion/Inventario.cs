using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class Inventario : Form
    {

        private Fachada fachada;

        public Inventario(Fachada fachada)
        {
            InitializeComponent();
            this.fachada = fachada;
            this.cargarCombos();
        }

        private void cargarCombos()
        {
            this.cmbProducto.Items.Clear();
           

            DataSet data = this.fachada.consultarProductos();


            foreach (DataRow dr in data.Tables["Productos"].Rows)
            {
                cmbProducto.Items.Add(dr["proCodigo"].ToString());
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cmbProducto.Text == "no seleccion")
            {
                MessageBox.Show("debe escoger un codigo");
                return;
            }
            DataSet tabla = this.fachada.consultarProductoEspecifico(this.cmbProducto.Text);

            data.DataSource = tabla;
            data.DataMember = "Productos";
        }
    }
}
