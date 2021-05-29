using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class VentaCN
    {
        public static int InsertarVenta(VentaCE venta)
        {
            string script = "INSERT INTO venta VALUES(@fecVenta, @idCliente)";
            VentaCD ventaCD = new VentaCD();
            return ventaCD.ExecuteSql(script, venta);
        }

        public static List<VentaCE> ListarVentas()
        {
            string script = "SELECT * FROM venta";
            VentaCD ventaCD = new VentaCD();
            return ventaCD.ReaderSql(script);
        }

        public static List<VentaCE> BuscarById(int id)
        {
            string script = "SELECT * FROM venta WHERE id = @id";
            VentaCD ventaCD = new VentaCD();
            return ventaCD.ReaderSql(script, id);
        }
        public static List<VentaCE> BuscarByIdCliente(int id)
        {
            string script = "SELECT * FROM venta WHERE idCliente = @idCliente";
            VentaCD ventaCD = new VentaCD();
            return ventaCD.ReaderSql(script, 0, id);
        }
    }
}
