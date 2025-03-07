using System;
using CapaDatos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Cd_Clientes
    {

        CD_Conexion db_conexion = new CD_Conexion();
        SqlConnection conn;

        // Constructor
        public Cd_Clientes()
        {
            conn = db_conexion.MtdAbrirConexion();
        }

        public DataTable MtMostrarClientes()
        {
            string QryMostrarClientes = "usp_clientes_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarClientes, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarClientes = new DataTable();
            adapter.Fill(dtMostrarClientes);
            db_conexion.MtdCerrarConexion();
            return dtMostrarClientes;
        }

        /* Agregar Datos*/

        // Capa datos
        public void CP_mtdCrearCliente(string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
            conn.Open();
            string vUspInsertarCliente = "InsertarClientes";
            SqlCommand commInsertarCliente = new SqlCommand(vUspInsertarCliente, conn);
            commInsertarCliente.CommandType = CommandType.StoredProcedure;

            
            commInsertarCliente.Parameters.AddWithValue("@Nombre", Nombre);
            commInsertarCliente.Parameters.AddWithValue("@Direccion", Direccion);
            commInsertarCliente.Parameters.AddWithValue("@Departamento", Departamento);
            commInsertarCliente.Parameters.AddWithValue("@Pais", Pais);
            commInsertarCliente.Parameters.AddWithValue("@Categoria", Categoria);
            commInsertarCliente.Parameters.AddWithValue("@Estado", Estado);
            commInsertarCliente.ExecuteNonQuery();
        }





        // Capa datos
        public int CP_mtdActualizarClientes(string CodigoCliente, string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            conn.Open();
            string vUspActualizarCliente = "usp_clientes_editar";
            SqlCommand commActualizarCliente = new SqlCommand(vUspActualizarCliente, conn);
            commActualizarCliente.CommandType = CommandType.StoredProcedure;

            commActualizarCliente.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            commActualizarCliente.Parameters.AddWithValue("@Nombre", Nombre);
            commActualizarCliente.Parameters.AddWithValue("@Direccion", Direccion);
            commActualizarCliente.Parameters.AddWithValue("@Departamento", Departamento);
            commActualizarCliente.Parameters.AddWithValue("@Pais", Pais);
            commActualizarCliente.Parameters.AddWithValue("@Categoria", Categoria);
            commActualizarCliente.Parameters.AddWithValue("@Estado", Estado);

            vContarRegistrosAfectados = commActualizarCliente.ExecuteNonQuery();
            return vContarRegistrosAfectados;
        }


        /* Eliminar Datos*/

        // Capa Datos
        public int CP_mtdEliminarCuenta(string CodigoCliente)
        {
            int vCantidadRegistrosEliminados = 0;

            conn.Open();
            string vUspEliminarCliente = "usp_clientes_Eliminar";
            SqlCommand commEliminarCliente = new SqlCommand(vUspEliminarCliente, conn);
            commEliminarCliente.CommandType = CommandType.StoredProcedure;

            commEliminarCliente.Parameters.AddWithValue("@Codigo", CodigoCliente);

            vCantidadRegistrosEliminados = commEliminarCliente.ExecuteNonQuery();
            return vCantidadRegistrosEliminados;
        }



        /* Buscar Datos*/

        // Capa Datos
        public DataTable CP_mtdBuscarClientes(string codigo)
        {
            conn.Open();
            string vUspBuscarClientes = "usp_BuscarClientes";
            SqlCommand commBuscarClientes = new SqlCommand(vUspBuscarClientes, conn);
            commBuscarClientes.CommandType = CommandType.StoredProcedure;

            commBuscarClientes.Parameters.AddWithValue("@Id", codigo);

            SqlDataAdapter AdapBuscarCliente = new SqlDataAdapter(commBuscarClientes);
            DataTable dtBuscarClientes = new DataTable();
            AdapBuscarCliente.Fill(dtBuscarClientes);
            conn.Close();

            return dtBuscarClientes;
        }
    }


}
