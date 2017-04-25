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
    public partial class Factura : Form
    {

        private Fachada fachada;
        private DataTable tablaDetalle;
        private DataSet tablaBase;
        private List<List<String>> productos;
        private String vendedor;
      
        private int totalFactura;

        public Factura(Fachada fachada,String vendedor)
        {
            InitializeComponent();
            this.fachada = fachada;
            this.cargarCombos();
            this.crearEstructuraTabla();
            this.vendedor = vendedor;
          
          
        }

        private void crearEstructuraTabla() {
            this.tablaDetalle = new DataTable();
            this.tablaDetalle.TableName = "Detalle";
            this.tablaBase = new DataSet();
            this.tablaBase.Tables.Add(this.tablaDetalle);

            tablaDetalle.Columns.Add("facProducto", typeof(string));
            tablaDetalle.Columns.Add("facDescripcion", typeof(string));
            tablaDetalle.Columns.Add("facCantidad", typeof(string));
            tablaDetalle.Columns.Add("Valor", typeof(string));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /**
        carga los combos de cliente y de productos
        **/
        private void cargarCombos() {
            this.cmbCliente.Items.Clear();
            this.cmbProducto.Items.Clear();
            

            DataSet clientes = this.fachada.consultarClientes();
            DataSet productos = this.fachada.consultarProductos();
            this.productos = new List<List<string>>();


            foreach (DataRow dr in clientes.Tables["Clientes"].Rows)
            {
                cmbCliente.Items.Add(dr["cliDocumento"].ToString()+"-"+dr["cliNombre"].ToString());
                

            }

            foreach (DataRow dr in productos.Tables["Productos"].Rows)
            {
                cmbProducto.Items.Add(dr["proCodigo"].ToString()+"-"+dr["proDescripcion"].ToString());
                List<String> elementos = new List<string>();
                elementos.Add(dr["proCodigo"].ToString());
                elementos.Add(dr["proDescripcion"].ToString());
                elementos.Add(dr["proValor"].ToString());
                elementos.Add(dr["proCantidad"].ToString());
                this.productos.Add(elementos);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNumero.Text) || string.IsNullOrEmpty(this.txtCantidad.Text)) {
                MessageBox.Show("debe llenar los campos de numero de factura y cantidad");
                return;
            }
            if ((this.cmbCliente.Text == "no seleccion") || (this.cmbProducto.Text == "no seleccion")) {
                MessageBox.Show("debe llenar seleccionar un producto y un cliente");
                return;
            }

            String p = this.cmbProducto.Text;
            int c = Int32.Parse(this.txtCantidad.Text);

            char[] delimitador = { '-' };
            String[] indice = p.Split(delimitador);
            List<String> producto = this.productoEspecifico(indice[0]);
            String codigo = indice[0];
            String desc = indice[1];
            int valor = Int32.Parse(producto[2]);
            valor = valor * c;
            this.totalFactura += valor;


            if (!this.validarPSeleccionado(codigo, c,valor))
            {
                tablaDetalle.Rows.Add(codigo, desc, c, valor);
            }         

            data.DataSource = this.tablaBase;
            data.DataMember = "Detalle";

        }

        private bool validarPSeleccionado(String codigo,int cantidad,int valor) {
            foreach (DataRow df in this.tablaBase.Tables["Detalle"].Rows) {
                if (df["facProducto"].ToString() == codigo) {
                    df["facCantidad"] = Int32.Parse(df["facCantidad"].ToString())+ cantidad;
                    df["Valor"] = Int32.Parse(df["Valor"].ToString())+ valor;
                    return true;
                }
            }
            return false;
        }

        

        private List<String> productoEspecifico(String codigo) {
            List<String> lista = new List<string>();
            foreach(List<String> val in this.productos){
                if (val[0] == codigo) {
                    lista = val;
                    return lista;
                }
            }
            return lista;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNumero.Text) || string.IsNullOrEmpty(this.txtCantidad.Text))
            {
                MessageBox.Show("debe llenar los campos de numero de factura y cantidad");
                return;
            }
            if ((this.cmbCliente.Text == "no seleccion") || (this.cmbProducto.Text == "no seleccion"))
            {
                MessageBox.Show("debe llenar seleccionar un producto y un cliente");
                return;
            }

            String numero = this.txtNumero.Text;
            DateTime fecha = this.dateFecha.Value;
          
            char[] delimitador = {'-'};
            String[] cliente = this.cmbCliente.Text.Split(delimitador);
           

           bool val= this.fachada.registrarFactura(vendedor, cliente[0], numero, fecha, this.totalFactura, this.tablaBase);

            if (!val)
            {
                MessageBox.Show("existe un error al registrar la factura");
                return;
            }
            this.txtFactura.Text = this.totalFactura + "";
            MessageBox.Show("se registro de manera exitosa la factura");

            
            this.data.Columns.Clear();
            this.crearEstructuraTabla();          
            this.txtFactura.Text = this.totalFactura+"";
            this.totalFactura = 0;
            this.txtNumero.Text = "";
            this.txtCantidad.Text = "";
        }
    }
}
