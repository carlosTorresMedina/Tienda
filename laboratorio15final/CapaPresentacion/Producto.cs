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
    public partial class Producto : Form
    {

        private Fachada fachada;
        private String codigoA;

        public Producto(Fachada fachada)
        {
            InitializeComponent();
            this.fachada = fachada;
            this.cargarCombos();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Producto_Load(object sender, EventArgs e)
        {

        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void limpiar() {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtValor.Text = "";
            this.txtCantidad.Text = "";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCodigo.Text) || String.IsNullOrEmpty(this.txtDescripcion.Text) || String.IsNullOrEmpty(this.txtValor.Text) || String.IsNullOrEmpty(this.txtCantidad.Text) )
            {

                MessageBox.Show("Debe llenar todos los campos");
                return;
            }

            String codigo = this.txtCodigo.Text;
            String descripcion  = this.txtDescripcion.Text;
            float valor =  Int32.Parse(txtValor.Text);
            int cantidad = Int32.Parse(this.txtCantidad.Text);



            bool val = this.fachada.ingresarProducto(codigo,descripcion,valor,cantidad);
            if (val)
            {
                MessageBox.Show("se registro con exito");
               this.cargarCombos();
                this.limpiar();
            }
            else {
                MessageBox.Show("existe un error al registrar");
            }
        }

        private void cargarCombos() {
            this.cmbProducto.Items.Clear();
            this.cmbProductoM.Items.Clear();
            this.cmbProductoE.Items.Clear();

            DataSet data = this.fachada.consultarProductos();


            foreach (DataRow dr in data.Tables["Productos"].Rows)
            {
                cmbProducto.Items.Add(dr["proCodigo"].ToString());
                cmbProductoM.Items.Add(dr["proCodigo"].ToString());
                cmbProductoE.Items.Add(dr["proCodigo"].ToString());

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

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            DataSet data = this.fachada.consultarProductoEspecifico(this.cmbProductoM.Text);
            foreach (DataRow dr in data.Tables["Productos"].Rows)
            {
                this.txtCodigoM.Text = dr["proCodigo"].ToString();
                this.txtDescripcionM.Text = dr["proDescripcion"].ToString();
                this.txtValorM.Text = dr["proValor"].ToString();
                this.txtCantidadM.Text = dr["proCantidad"].ToString();
                this.codigoA = dr["proCodigo"].ToString();
               
            }
        }

        private void txtValorM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCantidadM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCodigoM.Text) || String.IsNullOrEmpty(this.txtDescripcionM.Text) || String.IsNullOrEmpty(this.txtValorM.Text) || String.IsNullOrEmpty(this.txtCantidadM.Text) )
            {

                MessageBox.Show("Debe llenar todos los campos");
                return;
            }

            String codigo = this.txtCodigoM.Text;
            String descripcion = this.txtDescripcionM.Text;
            int valor = Int32.Parse(this.txtValorM.Text);
            int cantidad = Int32.Parse(this.txtCantidadM.Text);

           

            bool val = this.fachada.actualizarProducto(this.codigoA, codigo,descripcion, valor, cantidad);
            if (val)
            {
                MessageBox.Show("actualizacion con exito");
                this.cargarCombos();
                this.limpiarModificar();
            }
            else {
                MessageBox.Show("existe un error al actualizar");
            }
        }

        private void limpiarModificar() {
            this.txtCodigoM.Text = "";
            this.txtDescripcionM.Text = "";
            this.txtValorM.Text = "";
            this.txtCantidadM.Text ="";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbProductoE.Text == "no seleccion")
            {
                MessageBox.Show("Debe seleccionar un producto");
                return;
            }
            bool val = this.fachada.eliminarProducto(cmbProductoE.Text);
            if (val)
            {
                MessageBox.Show("eliminacion exitosa");
                this.cargarCombos();
            }
            else {
                MessageBox.Show("existe un error al eliminar");
            }
        }
    }
}
