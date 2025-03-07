using System;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class CD_Carros
    {

        
    
        CD_Conexion db_conexion = new CD_Conexion();
        SqlConnection conn;

        // Constructor
        public CD_Carros()
        {
            conn = db_conexion.MtdAbrirConexion();
        }

        public DataTable MtMostrarCarros()
        {
            string QryMostrarCarros = "usp_Vehiculos_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarCarros,db_conexion.MtdAbrirConexion());
            DataTable dtMostrarCarros = new DataTable();
            adapter.Fill(dtMostrarCarros);
            db_conexion.MtdCerrarConexion();
            return dtMostrarCarros;
        }

        /* Agregar Datos*/

        // Capa datos
        public void CP_mtdCrearCarros( string Marca, string Modelo, string Año, string Precio, string Estado)
        {
            conn.Open();
            string vUspInsertarCarros = "usp_Vehiculos_insert ";
            SqlCommand commInsertarCarros = new SqlCommand(vUspInsertarCarros, conn);
            commInsertarCarros.CommandType = CommandType.StoredProcedure;

            
            commInsertarCarros.Parameters.AddWithValue("@Marca", Marca);
            commInsertarCarros.Parameters.AddWithValue("@Modelo", Modelo);
            commInsertarCarros.Parameters.AddWithValue("@Año", Año);
            commInsertarCarros.Parameters.AddWithValue("@Precio", Precio);
            commInsertarCarros.Parameters.AddWithValue("@Estado", Estado);
            commInsertarCarros.ExecuteNonQuery();
        }





        // Capa datos
        public int CP_mtdActualizarCarros(string VehiculoID, string Marca, string Modelo, string Año, string Precio, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            conn.Open();
            string vUspActualizarCarros = "Usp_Vehiculos_Actualizar";
            SqlCommand commActualizarCarros = new SqlCommand(vUspActualizarCarros, conn);
            commActualizarCarros.CommandType = CommandType.StoredProcedure;

            commActualizarCarros.Parameters.AddWithValue("@VehiculoID", VehiculoID);
            commActualizarCarros.Parameters.AddWithValue("@Marca", Marca);
            commActualizarCarros.Parameters.AddWithValue("@Modelo", Modelo);
            commActualizarCarros.Parameters.AddWithValue("@Año", Año);
            commActualizarCarros.Parameters.AddWithValue("@Precio", Precio);
            commActualizarCarros.Parameters.AddWithValue("@Estado", Estado);

            vContarRegistrosAfectados = commActualizarCarros.ExecuteNonQuery();
            return vContarRegistrosAfectados;
        }


        /* Eliminar Datos*/

        // Capa Datos
        public int CP_mtdEliminarCarros(string VehiculoID)
        {
            int vCantidadRegistrosEliminados = 0;

            conn.Open();
            string vUspEliminarCarros = "Usp_Vehiculos_Eliminar";
            SqlCommand commEliminarCarros = new SqlCommand(vUspEliminarCarros, conn);
            commEliminarCarros.CommandType = CommandType.StoredProcedure;

            commEliminarCarros.Parameters.AddWithValue("@VehiculoID", VehiculoID);

            vCantidadRegistrosEliminados = commEliminarCarros.ExecuteNonQuery();
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


