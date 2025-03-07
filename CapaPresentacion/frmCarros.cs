using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class frmCarros : Form
    {
        public frmCarros()
        {
            InitializeComponent();
        }

        /*    
        public void MtdMostrarClientes()
        {
            CD_Clientes cd_clientes = new CD_Clientes();
            DataTable dtClientes = cd_clientes.MtMostrarClientes();
            dgvClientes.DataSource = dtClientes;
        }
        */

        public void MtdMostrarCarros()
        {

            CD_Carros cd_Carros = new CD_Carros();
            DataTable dtMostrarCarros= cd_Carros.MtMostrarCarros();
            dgvCarros.DataSource = dtMostrarCarros;
        }

        // Capa presentación
        public void mtdCrearCarros()
        {
            CD_Carros cd_Carros = new CD_Carros();

            
            string Marca= txtMarca.Text;
            string Modelo = txtModelo.Text;
            string Año = txtAño.Text;
            string Precio = txtPrecio.Text;
            string Estado = cboxEstado.SelectedItem != null ? cboxEstado.SelectedItem.ToString() : string.Empty;

            cd_Carros.CP_mtdCrearCarros( Marca, Modelo, Año, Precio, Estado);
            MessageBox.Show("Registro agregado!!!", "Correcto!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Capa presentación
        public void mtdActualizarCarros()
        {
            CD_Carros cd_Carros = new CD_Carros ();

            string VehiculoID = txtVehiculoID.Text;
            string Marca = txtMarca.Text;
            string Modelo = txtModelo.Text;
            string Año = txtAño.Text;
            string Precio = txtPrecio.Text;
            string Estado = cboxEstado.SelectedItem != null ? cboxEstado.SelectedItem.ToString() : string.Empty;


            int vCantidadRegistros = cd_Carros.CP_mtdActualizarCarros(VehiculoID, Marca, Modelo, Año, Precio, Estado);

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registros Actualizado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró codigo!!", "Error actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        // Capa presentación
        public void mtdEliminarCarros()
        {
            CD_Carros cp_classCarros = new CD_Carros();

            string VehiculoID = txtVehiculoID.Text;
            int vCantidadRegistros = cp_classCarros.CP_mtdEliminarCarros(VehiculoID);

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvSistemaVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVehiculoID.Text = dgvCarros.SelectedCells[0].Value.ToString();
            txtMarca.Text = dgvCarros.SelectedCells[1].Value.ToString();
            txtModelo.Text = dgvCarros.SelectedCells[2].Value.ToString();
            txtAño.Text = dgvCarros.SelectedCells[3].Value.ToString();
            txtPrecio.Text = dgvCarros.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvCarros.SelectedCells[5].Value.ToString();
        }   

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            MtdMostrarCarros();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void gboxClientes_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            mtdCrearCarros();
            MtdMostrarCarros();
            mtdlimpiarcampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mtdActualizarCarros();
            MtdMostrarCarros();
            mtdlimpiarcampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdlimpiarcampos();

        }

        private void mtdlimpiarcampos()
        {

            txtVehiculoID.Text = " ";
            txtMarca.Text = " ";
            txtModelo.Text = " ";
            txtAño.Text = " ";
            txtPrecio.Text = " ";
            cboxEstado.Text = " "; 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            mtdEliminarCarros();
            MtdMostrarCarros();
        }

        private void dgvCuenta_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
