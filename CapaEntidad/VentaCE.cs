using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaCE
    {
        int id;
        DateTime fecVenta;
        int idCliente;

        // Constructs
        public VentaCE() { }
        public VentaCE(int vId, DateTime vFecVenta, int vIdCliente)
        {
            this.id = vId;
            this.fecVenta = vFecVenta;
            this.idCliente = vIdCliente;
        }

        // Encapsulated
        public int Id { get { return id; } set { id = value; } }
        public DateTime FecVenta { get { return fecVenta; } set { fecVenta = value; } }
        public int IdCliente { get { return idCliente; } set { idCliente = value; } }
    }
}
