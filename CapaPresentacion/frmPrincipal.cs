using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            //MDI: Interfaz de multiples documentos
            this.IsMdiContainer = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rpta = MessageBox.Show(
                "Está a punto de cerrar el sisteam. ¿Esta seguro?",
                "¡Advertencia!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
            if (rpta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        //private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmCliente.Instancia.MdiParent = this;
        //    frmCliente.Instancia.WindowState = FormWindowState.Maximized;
        //    frmCliente.Instancia.Show();

        //    //frmCliente cliente = new frmCliente();
        //    //cliente.MdiParent = this;
        //    //cliente.WindowState = FormWindowState.Maximized;
        //    //cliente.Show();
        //}

        //private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //Forma B - SINGLETON
        //    // Paso 3: Invocar a la instancia
        //    frmProductos.Instancia.MdiParent = this;
        //    frmProductos.Instancia.WindowState = FormWindowState.Maximized;
        //    frmProductos.Instancia.Show();

        //    // Forma A 
        //    //frmProductos producto = new frmProductos();
        //    //producto.MdiParent = this;
        //    //producto.WindowState = FormWindowState.Maximized;
        //    //producto.Show();
        //}

        //private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmRegistroVenta.Instancia.MdiParent = this;
        //    frmRegistroVenta.Instancia.WindowState = FormWindowState.Maximized;
        //    frmRegistroVenta.Instancia.Show();

        //    //frmRegistroVenta venta = new frmRegistroVenta();
        //    //venta.MdiParent = this;
        //    //venta.WindowState = FormWindowState.Maximized;
        //    //venta.Show();
        //}

        private void RegistroVentas_Click(object sender, EventArgs e)
        {
            OpenFormChild(frmRegistroVenta.Instancia);

            VisibleArrow();
            Arrow.Location = new Point(4, 35);

        }

        private void Productos_Click(object sender, EventArgs e)
        {
            OpenFormChild(frmProductos.Instancia);
            VisibleArrow();
            Arrow.Location = new Point(4, 135);
        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            OpenFormChild(frmCliente.Instancia);
            VisibleArrow();
            Arrow.Location = new Point(4, 235);
        }

        private void Ventas_Click(object sender, EventArgs e)
        {
            OpenFormChild(frmDetalle.Instancia);
            VisibleArrow();
            Arrow.Location = new Point(4, 535);
        }

        private void OpenFormChild(Form formChild)
        {
            if (PanelContenedor.Controls.Count > 0)
                PanelContenedor.Controls.RemoveAt(0);

            formChild.TopLevel = false;
            formChild.Dock = DockStyle.Fill;
            PanelContenedor.Controls.Add(formChild);
            PanelContenedor.Tag = formChild;
            formChild.Show();
        }

        private void VisibleArrow()
        {
            if (!Arrow.Visible)
            {
                Arrow.Visible = true;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
