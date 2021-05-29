using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClienteCN
    {
        // Metodo -> Listar Clientes
        public static List<ClienteCE> ListarCliente()
        {
            // Script SQL
            string script = "SELECT * FROM cliente";
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.ReaderCliente(script, 0);
        }

        // Buscar Clientes
        public static List<ClienteCE> BuscarCliente(string buscar)
        {
            // Script SQL
            string script = "SELECT * FROM cliente where nombre like '%' + @valor + '%'";
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.ReaderCliente(script, 0, buscar);
        }

        public static ClienteCE BuscarClienteId(int id)
        {
            // Script SQL
            string script = "SELECT * FROM cliente where id = @id";
            ClienteCD clienteCD = new ClienteCD();

            if (clienteCD.ReaderCliente(script, id).Count > 0)
            {
                return clienteCD.ReaderCliente(script, id)[0];
            }
            else
            {
                return new ClienteCE();
            }

        }

        // Insertar Cliente
        public static int insertarCliente(ClienteCE cliente)
        {
            ClienteCD clienteCD = new ClienteCD();

            // Script SQL
            string script = "INSERT INTO cliente(nombre, numruc, direccion, telefono) VALUES(@nombre, @numruc, @direccion, @telefono)";
            return clienteCD.ExecuteCliente(script, cliente);
        }

        // Actualizar Cliente
        public static bool ActualizarCliente(ClienteCE cliente)
        {
            // Script SQL
            string script = "UPDATE cliente set nombre = @nombre, numruc = @numruc, direccion = @direccion, telefono = @telefono where id = @id";
            ClienteCD clienteCD = new ClienteCD();
            return (clienteCD.ExecuteCliente(script, cliente) > 0);
        }

        // Eliminar Cliente
        public static bool eliminarCliente(ClienteCE cliente)
        {
            // Script SQL
            string script = "DELETE FROM cliente where id = @id";
            ClienteCD clienteCD = new ClienteCD();
            return (clienteCD.ExecuteCliente(script, cliente) > 0);
        }
    }
}
