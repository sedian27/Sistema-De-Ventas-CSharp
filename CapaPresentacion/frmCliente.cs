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
    public partial class frmCliente : Form
    {
        private static frmCliente instancia = null;
        public static frmCliente Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                {
                    instancia = new frmCliente();
                }
                return instancia;
            }
        }
        public frmCliente()
        {
            InitializeComponent();
            actualizar();
        }

        private void actualizar()
        {
            dgvClientes.DataSource = ClienteCN.ListarCliente();
        }

        private void limpiar()
        {
            txtId.Text = "0";
            txtNombre.Clear();
            txtNumRuc.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            string numruc = txtNumRuc.Text;
            string direccion = txtDireccion.Text;
            int telefono = Convert.ToInt32(txtTelefono.Text);
            ClienteCE cliente = new ClienteCE(id, nombre, numruc, direccion, telefono);
            if (id == 0)
            {
                txtId.Text = ClienteCN.insertarCliente(cliente).ToString();
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
                if (ClienteCN.ActualizarCliente(cliente))
                {
                    MessageBox.Show("Se actualizo correctamente",
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
                    ClienteCE cliente = new ClienteCE(Convert.ToInt32(txtId.Text));
                    if (ClienteCN.eliminarCliente(cliente))
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string buscar = txtBuscar.Text;
            dgvClientes.DataSource = ClienteCN.BuscarCliente(buscar);
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            int cantFilasSeleccionadas = dgvClientes.SelectedRows.Count;
            if (cantFilasSeleccionadas > 0)
            {
                DataGridViewRow filaSel = dgvClientes.SelectedRows[0];

                txtId.Text = filaSel.Cells["id"].Value.ToString();
                txtNombre.Text = filaSel.Cells["nombre"].Value.ToString();
                txtNumRuc.Text = filaSel.Cells["numruc"].Value.ToString();
                txtDireccion.Text = filaSel.Cells["direccion"].Value.ToString();
                txtTelefono.Text = filaSel.Cells["telefono"].Value.ToString();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                ClienteCE cliente = ClienteCN.BuscarClienteId(Convert.ToInt32(txtId.Text));
                List<ClienteCE> clienteLs = new List<ClienteCE>();
                clienteLs.Add(cliente);
                dgvClientes.DataSource = clienteLs;
                
                txtNombre.Text = cliente.Nombre;
                txtNumRuc.Text = cliente.NumRuc;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono.ToString();

            }
        }
    }
}
