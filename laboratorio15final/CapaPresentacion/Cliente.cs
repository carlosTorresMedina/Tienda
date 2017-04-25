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
    public partial class Cliente : Form
    {
        private Fachada fachada;
        private String nDocumentoAuxiliar;

        public Cliente(Fachada fachada)
        {
            InitializeComponent();
            this.fachada = fachada;
            this.cargarCombos();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtDocumento.Text) || String.IsNullOrEmpty(this.txtNombre.Text) || String.IsNullOrEmpty(this.txtDireccion.Text) || String.IsNullOrEmpty(this.txtTelefono.Text) || String.IsNullOrEmpty(this.txtCorreo.Text)) {

                MessageBox.Show("Debe llenar todos los campos");
                return;
            }

            String nDocumento = this.txtDocumento.Text;
            String nombre = this.txtNombre.Text;
            String direccion = this.txtDireccion.Text;
            String telefono = this.txtTelefono.Text;
            String correo = this.txtCorreo.Text;

            bool val = this.fachada.ingresarCliente(nDocumento, nombre, direccion, telefono, correo);
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

        private void limpiar() {
            this.txtDocumento.Text = "";
            this.txtNombre.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            this.txtCorreo.Text = "";
        }

        private void limpiarModificar() {
            this.txtDocumentoM.Text = "";
            this.txtNombreM.Text = "";
            this.txtDireccionM.Text = "";
            this.txtTelefonoM.Text = "";
            this.txtCorreoM.Text = "";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {


        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (this.cmbCliente.Text == "no seleccion") {
                MessageBox.Show("debe escoger un numero de documento");
                return;
            }
            DataSet tabla = this.fachada.consultarClienteEspecifico(this.cmbCliente.Text);

            data.DataSource = tabla;
            data.DataMember = "Clientes";
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        /**
        carga todos los combos de la gui cliente
    **/
        private void cargarCombos()
        {

            this.cmbCliente.Items.Clear();
            this.cmbClienteM.Items.Clear();
            this.cmbClienteE.Items.Clear();

            DataSet data = this.fachada.consultarClientes();


            foreach (DataRow dr in data.Tables["Clientes"].Rows)
            {
                cmbCliente.Items.Add(dr["cliDocumento"].ToString());
                cmbClienteM.Items.Add(dr["cliDocumento"].ToString());
                cmbClienteE.Items.Add(dr["cliDocumento"].ToString());

            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            DataSet data = this.fachada.consultarClienteEspecifico(this.cmbClienteM.Text);
            foreach (DataRow dr in data.Tables["Clientes"].Rows) {
                this.txtDocumentoM.Text = dr["cliDocumento"].ToString();
                this.txtNombreM.Text = dr["cliNombre"].ToString();
                this.txtDireccionM.Text = dr["cliDireccion"].ToString();
                this.txtTelefonoM.Text = dr["cliTelefono"].ToString();
                this.txtCorreoM.Text = dr["cliCorreo"].ToString();
                this.nDocumentoAuxiliar = dr["cliDocumento"].ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtDocumentoM.Text) || String.IsNullOrEmpty(this.txtNombreM.Text) || String.IsNullOrEmpty(this.txtDireccionM.Text) || String.IsNullOrEmpty(this.txtTelefonoM.Text) || String.IsNullOrEmpty(this.txtCorreoM.Text))
            {

                MessageBox.Show("Debe llenar todos los campos");
                return;
            }

            String nDocumento = this.txtDocumentoM.Text;
            String nombre = this.txtNombreM.Text;
            String direccion = this.txtDireccionM.Text;
            String telefono = this.txtTelefonoM.Text;
            
            String correo = this.txtCorreoM.Text;

            bool val = this.fachada.actualizarCliente(this.nDocumentoAuxiliar,nDocumento, nombre, direccion, telefono, correo);
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

        private void txtTelefonoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbClienteE.Text == "no seleccion") {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            bool val = this.fachada.eliminarCliente(cmbClienteE.Text);
            if (val)
            {
                MessageBox.Show("eliminacion exitosa");
                this.cargarCombos();
            }
            else {
                MessageBox.Show("existe un error al eliminar");
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }
    }
}
