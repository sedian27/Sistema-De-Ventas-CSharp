using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ProductoCN
    {

        // Metodo -> Listar Productos
        public static List<ProductoCE> ListarProducto()
        {
            // Propiedades
            ProductoCD pCD = new ProductoCD();
            string consulta = "SELECT * FROM producto";
            return pCD.ReaderProductos(consulta);
        }

        // Buscar Productos
        public static List<ProductoCE> BuscarProducto(string buscar)
        {
            // Propiedades
            ProductoCD pCD = new ProductoCD();
            string consulta = "SELECT * FROM producto where descripcion like '%' + @valor + '%'";
            return pCD.ReaderProductos(consulta, 0, buscar);
        }

        public static ProductoCE BuscarProductoId(int id)
        {
            // Propiedades
            ProductoCD pCD = new ProductoCD();
            string consulta = "SELECT * FROM producto where id = @id";
            if (pCD.ReaderProductos(consulta, id, "").Count > 0)
            {
                return pCD.ReaderProductos(consulta, id, "")[0];
            }
            else
            {
                return new ProductoCE();
            }
        }

        // Insertar Producto
        public static int InsertarProducto(ProductoCE producto)
        {
            //instanciar
            ProductoCD pCD = new ProductoCD();
            string consulta = "INSERT INTO producto(descripcion, categoria, precio) VALUES(@descripcion, @categoria, @precio)";
            return pCD.ExecuteProductos(consulta, producto);
        }

        // Actualizar Producto
        public static bool ActualizarProducto(ProductoCE producto)
        {
            //instanciar
            ProductoCD pCD = new ProductoCD();
            string consulta = "UPDATE producto set descripcion = @descripcion, categoria = @categoria, precio = @precio where id = @id";
            return (pCD.ExecuteProductos(consulta, producto) > 0);
        }

        // Eliminar Producto
        public static bool EliminarProducto(ProductoCE producto)
        {
            //instanciar
            ProductoCD pCD = new ProductoCD();
            string consulta = "DELETE FROM producto where id = @id";
            return (pCD.ExecuteProductos(consulta, producto) > 0);
        }

    }
}
