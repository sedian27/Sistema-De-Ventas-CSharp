using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClienteCD
    {
        //Metodos del crud
        // Leer Datos
        public List<ClienteCE> ReaderCliente(string query, int idBuscar, string buscar = "")
        {
            ConexionCD db = new ConexionCD();
            db.AbrirConexion();

            SqlCommand cmd = db.Comando();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", idBuscar);
            cmd.Parameters.AddWithValue("@valor", buscar);
            SqlDataReader drCliente = cmd.ExecuteReader();
            // Declarar una coleccion de clientes
            List<ClienteCE> lstCliente = new List<ClienteCE>();

            // Moviendo el puntero de registro
            // Hasta finalizar la tabla

            while (drCliente.Read())
            {
                int id = Convert.ToInt32(drCliente["id"]);
                string nombre = drCliente["nombre"].ToString();
                string numruc = drCliente["numruc"].ToString();
                string direccion = drCliente["direccion"].ToString();
                int telefono = Convert.ToInt32(drCliente["telefono"]);
                // Instanciar un nuevo cliente
                ClienteCE cliente = new ClienteCE(id, nombre, numruc, direccion, telefono);
                lstCliente.Add(cliente);
            }

            db.CerrarConexion();
            return lstCliente;
        }

        // Insertar, Actualizar y Eliminar;
        public int ExecuteCliente(string query, ClienteCE cliente)
        {
            ConexionCD db = new ConexionCD();
            SqlConnection cnx = db.AbrirConexion();
            //crear un comando vinculado a la conexión.
            // Establecer el tipo
            SqlCommand cmd = db.Comando();
            // Asignar el script SQL al comando
            cmd.CommandText = query;
            // Leer valores a actualizar
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@numruc", cliente.NumRuc);
            cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@id", cliente.Id);

            int newId = 0;
            //Ejecutar comando
            using (SqlTransaction transaccion = cnx.BeginTransaction())
            {
                cmd.Transaction = transaccion;
                newId = cmd.ExecuteNonQuery(); // UPDATE, INSERT, DELETE
                try
                {
                    transaccion.Commit();
                    if (query.Contains("INSERT"))
                    {
                        cmd.CommandText = "SELECT max(id) as nuevoId FROM cliente where nombre = @nombre";
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            newId = Convert.ToInt32(reader["nuevoId"]);
                        }
                    }
                }
                catch
                {
                    transaccion.Rollback();
                }
            }

            db.CerrarConexion();
            return newId;
        }
    }
}
