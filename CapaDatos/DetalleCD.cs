using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DetalleCD
    {
        public List<DetalleCE> ReaderSql(string script, int vIdVenta = 0, int vIdProducto = 0)
        {
            ConexionCD db = new ConexionCD();
            db.AbrirConexion();
            SqlCommand cmd = db.Comando();
            cmd.CommandText = script;
            cmd.Parameters.AddWithValue("@idVenta", vIdVenta);
            cmd.Parameters.AddWithValue("@idProducto", vIdProducto);
            SqlDataReader drDetalle = cmd.ExecuteReader();
            List<DetalleCE> lstDetalle = new List<DetalleCE>();
            while (drDetalle.Read())
            {
                string nombre = drDetalle["nombre"].ToString();
                string descripcion = drDetalle["descripcion"].ToString();
                int cantidad = Convert.ToInt32(drDetalle["cantidad"]);
                double total = Convert.ToDouble(drDetalle["total"]);
                DetalleCE detalle = new DetalleCE(nombre, descripcion, cantidad, total);
                lstDetalle.Add(detalle);
            }
            db.CerrarConexion();
            return lstDetalle;
        }

        public void ExecuteSql(string script, DetalleCE detalle)
        {
            ConexionCD db = new ConexionCD();
            SqlConnection cnx = db.AbrirConexion();
            SqlCommand cmd = db.Comando();
            cmd.CommandText = script;
            cmd.Parameters.AddWithValue("@id", detalle.Id);
            cmd.Parameters.AddWithValue("@idVenta", detalle.IdVenta);
            cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
            cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
            using (SqlTransaction transaccion = cnx.BeginTransaction())
            {
                cmd.Transaction = transaccion;
                cmd.ExecuteNonQuery();
            }
            db.CerrarConexion();
        }
    }
}
