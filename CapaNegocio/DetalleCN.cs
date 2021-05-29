using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DetalleCN
    {
        public void InsertarDetalle(DetalleCE detalle)
        {
            string script = "INSERT INTO detalle VALUES(@idVenta, @idProducto, @cantidad)";
            DetalleCD detalleCD = new DetalleCD();
            detalleCD.ExecuteSql(script, detalle);
        }

        public List<DetalleCE> ListarDetalle()
        {
            string script = "SELECT c.nombre, p.descripcion, dt.cantidad, (p.precio * dt.cantidad) as 'total' FROM venta as v " +
                            "INNER JOIN detalle as dt on dt.idVenta = v.id " +
                            "INNER JOIN producto as p on p.id = dt.idProducto " +
                            "INNER JOIN cliente as c on c.id = v.idCliente";
            DetalleCD detalleCD = new DetalleCD();
            return detalleCD.ReaderSql(script);
        }

        public List<DetalleCE> BuscarDetalleByIdVenta(int idVenta)
        {
            string script = "SELECT * FROM detalle where idVenta = @idVenta";
            DetalleCD detalleCD = new DetalleCD();
            return detalleCD.ReaderSql(script, idVenta);
        }
        public List<DetalleCE> BuscarDetalleByIdProducto(int idProducto)
        {
            string script = "SELECT * FROM detalle where idProducto = @idProducto";
            DetalleCD detalleCD = new DetalleCD();
            return detalleCD.ReaderSql(script, 0, idProducto);
        }

        public void EliminarDetalle(DetalleCE detalle)
        {
            string script = "DELETE FROM detalle where id = @id";
            DetalleCD detalleCD = new DetalleCD();
            detalleCD.ExecuteSql(script, detalle);
        }


    }
}
