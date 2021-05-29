using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class VentaCD
    {
        public List<VentaCE> ReaderSql(string script, int idBuscar = 0, int vIdCliente = 0)
        {
            ConexionCD db = new ConexionCD();
            db.AbrirConexion();
            SqlCommand cmd = db.Comando();
            cmd.CommandText = script;
            cmd.Parameters.AddWithValue("@id", idBuscar);
            cmd.Parameters.AddWithValue("@idCliente", vIdCliente);
            SqlDataReader drVenta = cmd.ExecuteReader();
            List<VentaCE> lstVenta = new List<VentaCE>();
            while (drVenta.Read())
            {
                int id = Convert.ToInt32(drVenta["id"]);
                DateTime fecventa = Convert.ToDateTime(drVenta["fecventa"]);
                int idCliente = Convert.ToInt32(drVenta["idCliente"]);
                VentaCE venta = new VentaCE(id, fecventa, idCliente);
                lstVenta.Add(venta);
            }
            db.CerrarConexion();
            return lstVenta;
        }

        public int ExecuteSql(string script, VentaCE venta)
        {
            ConexionCD db = new ConexionCD();
            SqlConnection cnx = db.AbrirConexion();
            SqlCommand cmd = db.Comando();
            cmd.CommandText = script;
            cmd.Parameters.AddWithValue("@id", venta.Id);
            cmd.Parameters.AddWithValue("@fecVenta", venta.FecVenta);
            cmd.Parameters.AddWithValue("@idCliente", venta.IdCliente);

            int newId = 0;
            using (SqlTransaction transaccion = cnx.BeginTransaction())
            {
                cmd.Transaction = transaccion;
                try
                {
                    // Ejecuta el comando
                    newId = cmd.ExecuteNonQuery();
                    // Confirma la transaccion
                    transaccion.Commit();
                    if (script.Contains("INSERT"))
                    {
                        cmd.CommandText = "SELECT max(id) as newId FROM venta WHERE idCliente = @idCliente";
                        SqlDataReader drVenta = cmd.ExecuteReader();
                        if (drVenta.Read())
                        {
                            newId = Convert.ToInt32(drVenta["newId"]);
                        }
                    }
                }
                catch
                {
                    // Deshacer la transaccion
                    transaccion.Rollback();
                }
            }

            db.CerrarConexion();
            return newId;
        }
    }
}
