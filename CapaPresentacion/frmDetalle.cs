using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmDetalle : Form
    {
        private static frmDetalle instancia = null;
        public static frmDetalle Instancia
        {
            get
            {
                if(instancia == null || instancia.IsDisposed)
                {
                    instancia = new frmDetalle();
                }
                return instancia;
            }
        }
        public frmDetalle()
        {
            InitializeComponent();
            DetalleCN detalleCN = new DetalleCN();
            foreach(var dt in detalleCN.ListarDetalle())
            {
                DgvDetalle.Rows.Add(dt.Cliente, dt.Producto, dt.Cantidad, dt.Total);
            }
        }
    }
}
