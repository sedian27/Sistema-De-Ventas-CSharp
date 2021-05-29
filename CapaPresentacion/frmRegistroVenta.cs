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
using CapaEntidad;
namespace CapaPresentacion
{
    public partial class frmRegistroVenta : Form
    {
        private static frmRegistroVenta instancia = null;
        public static frmRegistroVenta Instancia
        {
            get
            {
                if(instancia == null || instancia.IsDisposed)
                {
                    instancia = new frmRegistroVenta();
                }
                return instancia;
            }
        }
        public frmRegistroVenta()
        {
            InitializeComponent();
        }

        private void resetfila()
        {
            txtIdProducto.Text = "0";
            txtProducto.Clear();
            txtPrecio.Text = "0.00";
        }

        private void resetControl()
        {
            resetfila();
            txtCliente.Clear();
            txtIdCliente.Text = "0";
            txtTotal.Text = "0.00";
            dgvDetalle.Rows.Clear();
        }

        private void timFecha_Tick(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            txtFecha.Text = fecha.ToString("yyyy-MM-dd hh:mm:ss");

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            // Instanciar el frmCliente
            frmCliente clienteCP = new frmCliente();

            // Mostrar la instancia
            clienteCP.FormBorderStyle = FormBorderStyle.FixedSingle;
            clienteCP.ShowDialog();

            // Recoger los valores de las cajas de texto para enviarlos al otro formulario
            txtIdCliente.Text = clienteCP.Controls["txtId"].Text;
            txtCliente.Text = clienteCP.Controls["txtNombre"].Text;
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            // Instanciar el frmProducto
            frmProductos productoCP = new frmProductos();

            // Mostrar la instancia
            productoCP.FormBorderStyle = FormBorderStyle.FixedSingle;
            productoCP.ShowDialog();

            // Recoger los valores de las cajas de texto para enviarlos al otro formulario
            txtIdProducto.Text = productoCP.Controls["txtId"].Text;
            txtProducto.Text = productoCP.Controls["txtDescripcion"].Text;
            txtPrecio.Text = productoCP.Controls["txtPrecio"].Text;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double precio = txtPrecio.Text.Length > 0 ? Convert.ToDouble(txtPrecio.Text) : 0;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double total = precio * cantidad;
            double totalVenta = 0.00;

            bool existe = false;
            if (txtProducto.Text.Length <= 0 || txtCantidad.Text == "0")
            {
                MessageBox.Show("No puede agregar un producto inexistente!");
            }
            else
            {
                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    if (fila.Cells["clId"].Value.ToString() == txtIdProducto.Text)
                    {
                        fila.Cells["clCantidad"].Value = Convert.ToInt32(fila.Cells["clCantidad"].Value) + Convert.ToInt32(txtCantidad.Text);
                        fila.Cells["clTotal"].Value = Convert.ToDouble(fila.Cells["clTotal"].Value) + total;
                        existe = true;
                    }
                }
                if (!existe)
                {
                    dgvDetalle.Rows.Add(txtIdProducto.Text, txtProducto.Text, precio.ToString(), cantidad.ToString(), total.ToString());
                }
                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    totalVenta += Convert.ToDouble(fila.Cells["clTotal"].Value);
                }
                txtTotal.Text = totalVenta.ToString("0.00");
                resetfila();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text.Length <= 0)
            {
                MessageBox.Show("Ingrese un cliente valido!");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de insertar?",
                                                      "Insertar",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Information,
                                                      MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {

                    // FASE I: Insertar venta
                    VentaCE venta = new VentaCE(0, Convert.ToDateTime(txtFecha.Text),
                                                   Convert.ToInt32(txtIdCliente.Text));
                    int idVenta = VentaCN.InsertarVenta(venta);
                    if(idVenta > 0)
                    {
                        foreach (DataGridViewRow fila in dgvDetalle.Rows)
                        {
                            // FASE II: Detalle
                            int id = Convert.ToInt32(fila.Cells["clId"].Value);
                            //double precio = Convert.ToDouble(fila.Cells["clPrecio"].Value);
                            int cantidad = Convert.ToInt32(fila.Cells["clCantidad"].Value);
                            //double total = Convert.ToDouble(fila.Cells["clTotal"].Value);
                            DetalleCE detalle = new DetalleCE(0, idVenta, id, cantidad);
                            DetalleCN detalleCN = new DetalleCN();
                            detalleCN.InsertarDetalle(detalle);
                        }
                        MessageBox.Show("Se inserto correctamente!",
                            "Correcto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        resetControl();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error!",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    
                }
            }

        }

        private void txtIdCliente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int id = txtIdCliente.Text.Length > 0 ? Convert.ToInt32(txtIdCliente.Text) : 0;
                if (id != 0)
                {
                    ClienteCE cliente = ClienteCN.BuscarClienteId(id);
                    txtIdCliente.Text = cliente.Id.ToString();
                    txtCliente.Text = cliente.Nombre;
                }
            }
        }

        private void txtIdProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int id = txtIdProducto.Text.Length > 0 ? Convert.ToInt32(txtIdProducto.Text) : 0;
                if (id != 0)
                {
                    ProductoCE producto = ProductoCN.BuscarProductoId(id);
                    txtIdProducto.Text = producto.Id.ToString();
                    txtProducto.Text = producto.Descripcion;
                    txtPrecio.Text = producto.Precio.ToString("0.00");
                }
            }
        }
    }
}
