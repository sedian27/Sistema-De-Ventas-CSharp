using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importar la CapaEntidad
using CapaEntidad;
// Importar Librerias de datos
using System.Data;
// Importar la libreria para Sql
using System.Data.SqlClient;


namespace CapaDatos
{
    public class ProductoCD
    {
        //Metodos del crud
        // Leer Datos
        public List<ProductoCE> ReaderProductos(string query, int idBuscar = 0, string buscar = "")
        {
            ConexionCD db = new ConexionCD();
            db.AbrirConexion();

            SqlCommand cmd = db.Comando();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@valor", buscar);
            cmd.Parameters.AddWithValue("@id", idBuscar);
            SqlDataReader drProducto = cmd.ExecuteReader();
            // Declarar una coleccion de productos
            List<ProductoCE> lstProductos = new List<ProductoCE>();

            // Moviendo el puntero de registro
            // Hasta finalizar la tabla
            while (drProducto.Read())
            {
                int id = Convert.ToInt32(drProducto["id"]);
                string descripcion = drProducto["descripcion"].ToString();
                string categoria = drProducto["categoria"].ToString();
                double precio = Convert.ToDouble(drProducto["precio"]);
                // Instanciar un nuevo producto
                ProductoCE producto = new ProductoCE(id, descripcion, categoria, precio);
                lstProductos.Add(producto);
            }
            db.CerrarConexion();
            return lstProductos;
        }

        // Insertar, Actualizar y Eliminar;
        public int ExecuteProductos(string query, ProductoCE producto)
        {
            ConexionCD db = new ConexionCD();
            SqlConnection cnx = db.AbrirConexion();
            //crear un comando vinculado a la conexión.
            // Establecer el tipo
            SqlCommand cmd = db.Comando();
            // Asignar el script SQL al comando
            cmd.CommandText = query;
            // Leer valores a actualizar
            cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@categoria", producto.Categoria);
            cmd.Parameters.AddWithValue("@precio", producto.Precio);
            cmd.Parameters.AddWithValue("@id", producto.Id);

            int newId = 0;

            using (SqlTransaction transaccion = cnx.BeginTransaction())
            {
                cmd.Transaction = transaccion;
                try
                {
                    //Ejecutar comando
                    newId = cmd.ExecuteNonQuery(); // INSERT
                    transaccion.Commit();
                    if (query.Contains("INSERT"))
                    {
                        cmd.CommandText = "SELECT max(id) as newId FROM producto where          descripcion = @descripcion";
                        SqlDataReader drProducto = cmd.ExecuteReader();
                        if (drProducto.Read())
                        {
                            newId = Convert.ToInt32(drProducto["newId"]);
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
