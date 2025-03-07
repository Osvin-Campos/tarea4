using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            PanelSeleccion.Visible = false;
        }

        private void btnOcultarMenu_Click(object sender, EventArgs e)
        {
            if(PanelMenu.Width==200)
            {
                PanelMenu.Width = 40;
            }
            else
            {
                PanelMenu.Width=200;
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            PanelSeleccion.Top = btnClientes.Top; // Ajustar la posición de altura
            PanelSeleccion.Height = btnClientes.Height; // Ajustar el tamaño
            PanelSeleccion.Visible=true; // hacer visible el boton

            FrmClientes frmClie = new FrmClientes();
            if(this.PanelContenedor.Controls.Count > 0)
            {
                this.PanelContenedor.Controls.RemoveAt(0);
                frmClie.TopLevel = false;
                frmClie.Dock = DockStyle.Fill;
                this.PanelContenedor.Controls.Add(frmClie);
                this.PanelContenedor.Tag = frmClie;
                frmClie.Show();
            }

            
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            PanelSeleccion.Top = btnCarros.Top; // Ajustar la posición de altura
            PanelSeleccion.Height = btnCarros.Height; // Ajustar el tamaño
            PanelSeleccion.Visible = true; // hacer visible el boton

            frmCarros frmClie = new frmCarros();
            if (this.PanelContenedor.Controls.Count > 0)
            {
                this.PanelContenedor.Controls.RemoveAt(0);
                frmClie.TopLevel = false;
                frmClie.Dock = DockStyle.Fill;
                this.PanelContenedor.Controls.Add(frmClie);
                this.PanelContenedor.Tag = frmClie;
                frmClie.Show();
            }

        }
    }
}
