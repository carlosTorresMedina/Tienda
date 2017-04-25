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
    public partial class Principal : Form
    {

        private Producto producto;
        private Cliente cliente;
        private Inventario inventario;
        private Factura factura;
        private Fachada fachada;

        private String vendedor;

       
        public Principal(Fachada fachada,String vendedor)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.fachada = fachada;
            this.vendedor = vendedor;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.producto = new Producto(this.fachada);
                this.producto.MdiParent = this;     
            this.producto.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                this.cliente = new Cliente(this.fachada);
                this.cliente.MdiParent = this;       
            this.cliente.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
                this.factura = new Factura(this.fachada,this.vendedor);
                this.factura.MdiParent = this;
          
          
            this.factura.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
                this.inventario = new Inventario(this.fachada);
                this.inventario.MdiParent = this;
                     
            this.inventario.Show();
        }
    }
}
