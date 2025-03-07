using CapaDatos;
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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
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

        public void MtdMostrarClientes()
        {

            Cd_Clientes cd_Cliente = new Cd_Clientes();
            DataTable dtMostrarClientes = cd_Cliente.MtMostrarClientes();
            dgvClientes.DataSource = dtMostrarClientes;
        }

        // Capa presentación
        public void mtdCrearClientes()
        {
            Cd_Clientes cd_Cliente = new Cd_Clientes();

            
            string Nombre = txtNombre.Text;
            string Direccion  = txtDireccion.Text;
            string Departamento = txtDepartamento.Text;
            string Pais = txtPais.Text;
            string Categoria = textCategoria.Text;
            string Estado = cboxEstado.SelectedItem != null ? cboxEstado.SelectedItem.ToString() : string.Empty;

            cd_Cliente.CP_mtdCrearCliente(Nombre, Direccion, Departamento, Pais, Categoria, Estado);
            MessageBox.Show("Registro agregado!!!", "Correcto!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Capa presentación
        public void mtdActualizarClientes()
        {
            Cd_Clientes cd_Clientes = new Cd_Clientes();

            string CodigoCliente = txtCodigoCliente.Text;
            string Nombre = txtNombre.Text;
            string Direccion = txtDireccion.Text;
            string Departamento = txtDepartamento.Text;
            string Pais = txtPais.Text;
            string Categoria = textCategoria.Text;
            string Estado = cboxEstado.SelectedItem != null ? cboxEstado.SelectedItem.ToString() : string.Empty;

            int vCantidadRegistros = cd_Clientes.CP_mtdActualizarClientes( CodigoCliente, Nombre, Direccion, Departamento, Pais, Categoria, Estado);

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
        public void mtdEliminarClientes()
        {
            Cd_Clientes cp_classCliente = new Cd_Clientes();

            string CodigoCliente = txtCodigoCliente.Text;
            int vCantidadRegistros = cp_classCliente.CP_mtdEliminarCuenta(CodigoCliente);

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

    

        private void mtdlimpiarcampos()
        {

            txtCodigoCliente.Text = " ";
            txtNombre.Text = " ";
            txtDireccion.Text = " ";
            txtDepartamento.Text = " ";
            txtPais.Text = " ";
            textCategoria.Text = " ";

            cboxEstado.Text = " ";
        }

        

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtCodigoCliente.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtDireccion.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtDepartamento.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtPais.Text = dgvClientes.SelectedCells[4].Value.ToString();
            textCategoria.Text = dgvClientes.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvClientes.SelectedCells[6].Value.ToString();

        }

        private void FrmClientes_Load_1(object sender, EventArgs e)
        {
            MtdMostrarClientes();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            mtdCrearClientes();
            MtdMostrarClientes();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            mtdActualizarClientes();
            MtdMostrarClientes();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            mtdEliminarClientes();
            MtdMostrarClientes();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            mtdlimpiarcampos();

        }
    }
}
