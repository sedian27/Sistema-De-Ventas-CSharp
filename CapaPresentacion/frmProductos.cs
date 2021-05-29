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
    //Patron de diseño SINGLETON
    public partial class frmProductos : Form
    {
        // Paso 1: Declarar una propiedad para controlar las instancias.
        // - La propiedad deberá ser de la misma clase.
        // - Deberá tener como valor predeterminado: null.
        // - Deberá ser estatica para acceder sin intanciar.

        private static frmProductos instancia = null;

        // Paso 2: Encapsular la propiedad: instancia
        // - Encapsular para solo lectura (GET)
        public static frmProductos Instancia
        {
            get
            {
                // Si la intancia es nula o ha sido eliminada
                if(instancia == null || instancia.IsDisposed)
                {
                    // Instanciamos la clase
                    instancia = new frmProductos();
                }

                return instancia;
            }
        }

        // Paso 3: ... se realiza en el momento de llamar a la clase
        // - en el evento click del menu.

        public frmProductos()
        {
            InitializeComponent();
            actualizar();
        }

        private void actualizar()
        {
            dgvProductos.DataSource = ProductoCN.ListarProducto();
            dgvProductos.Columns["precio"].DefaultCellStyle.Format = "c";
            dgvProductos.Columns["precio"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
        }

        private void limpiar()
        {
            txtId.Text = "0";
            txtDescripcion.Clear();
            txtCategoria.Clear();
            txtPrecio.Text = "0.00";
            txtBuscar.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string descripcion = txtDescripcion.Text;
            string categoria = txtCategoria.Text;
            double precio = Convert.ToDouble(txtPrecio.Text);
            ProductoCE producto = new ProductoCE(id, descripcion, categoria, precio);
            if (id == 0)
            {
                txtId.Text = ProductoCN.InsertarProducto(producto).ToString();
                if (Convert.ToInt32(txtId.Text) > 0)
                {
                    MessageBox.Show("Se inserto correctamente",
                        "Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    actualizar();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                if(ProductoCN.ActualizarProducto(producto))
                {
                    MessageBox.Show("Se actualizo correctamente",
                        "Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    actualizar();

                }
                else
                {
                    MessageBox.Show("No se pudo actualizar",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Capturo el ID de la caja de texto
            if (txtId.Text != "0")
            {
                // Creamos el aviso y lo guardamos en un DialogResult
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                // Si dio click en si ejecutaremos el metodo eliminar.
                if (respuesta == DialogResult.Yes)
                {
                    // Mi Metodo recoge directamente un ProductoCE y solo le paso el dato ID
                    ProductoCE producto = new ProductoCE(Convert.ToInt32(txtId.Text));
                    if(ProductoCN.EliminarProducto(producto))
                    {
                        MessageBox.Show("Se elimino el registro",
                        "Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        // Actualizo el DataGrid
                        actualizar();
                        // Limpio los textbox
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontro ID");
            }
        }
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            //Metodo que se ejecuta cuando se selecciona una fila del GRID
            //Cantidad de Filas Seleccionadas
            int canFilasSeleccionadas = dgvProductos.SelectedRows.Count;
            if (canFilasSeleccionadas > 0)
            {
                DataGridViewRow filaSel = dgvProductos.SelectedRows[0];

                double precio = Convert.ToDouble(filaSel.Cells["precio"].Value);

                txtId.Text = filaSel.Cells["id"].Value.ToString();
                txtDescripcion.Text = filaSel.Cells["descripcion"].Value.ToString();
                txtCategoria.Text = filaSel.Cells["categoria"].Value.ToString();
                txtPrecio.Text = precio.ToString("0.00");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string buscar = txtBuscar.Text;
            dgvProductos.DataSource = ProductoCN.BuscarProducto(buscar);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = txtId.Text.Length > 0 ? Convert.ToInt32(txtId.Text) : 0;
            if (id > 0)
            {
                ProductoCE producto = ProductoCN.BuscarProductoId(id);
                List<ProductoCE> productoLs = new List<ProductoCE>();
                productoLs.Add(producto);
                dgvProductos.DataSource = productoLs;
            }
            else
            {
                actualizar();
            }
        }
    }
}
