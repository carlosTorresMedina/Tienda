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
    public partial class Inicio : Form
    {
       private Fachada fachada;
        public Inicio()
        {

            InitializeComponent();
            this.CenterToScreen();
            this.fachada = new Fachada();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            String nombre = txtUsuario.Text;
            String contra = txtContra.Text;
            bool valor = fachada.iniciarSesion(nombre,contra);
            if (valor)
            {
                Principal p = new Principal(this.fachada,nombre);
                this.Hide();
                p.ShowDialog();
                this.Show();
            }
            else {
                MessageBox.Show("digito mal los datos para ingresar !!");
            }

            
        }
    }
}
