using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleCE
    {
        int id = 0;
        int idVenta = 0;
        int idProducto = 0;
        int cantidad = 0;
        string cliente = "";
        string producto = "";
        double total = 0.00;

        // Constructores
        public DetalleCE() { }
        public DetalleCE(int vId = 0, int vIdVenta = 0, int vIdProducto = 0, int vCantidad = 0)
        {
            this.id = vId;
            this.idVenta = vIdVenta;
            this.idProducto = vIdProducto;
            this.cantidad = vCantidad;
        }

        public DetalleCE(string vCliente = "", string vProducto = "", int vCantidad = 0, double vTotal = 0.00)
        {
            this.cliente = vCliente;
            this.producto = vProducto;
            this.cantidad = vCantidad;
            this.total = vTotal;
        }

        // Encapsulados
        public int Id { get { return id; } set { id = value; } }
        public int IdVenta { get { return idVenta; } set { idVenta = value; } }
        public int IdProducto { get { return idProducto; } set { idProducto = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }
        public string Cliente { get { return cliente; } set { cliente = value; } }
        public string Producto { get { return producto; } set { producto = value; } }
        public double Total { get { return total; } set { total = value; } }
    }
}
