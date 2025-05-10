using System.Collections.Generic;
using System.Linq;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NProduct
    {
        private Dproducts dProduct = new Dproducts();

        // ✅ Listar todos los productos
        public List<Products> ListarProductos()
        {
            return dProduct.ListarProductos();
        }

        // ✅ Listar productos filtrados por nombre (contiene)
        public List<Products> ListarProductosPorNombre(string nombre)
        {
            var productos = dProduct.ListarProductos();
            return productos
                .Where(p => p.Name.Contains(nombre, System.StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // ✅ Insertar un nuevo producto
        public void InsertarProducto(Products producto)
        {
            dProduct.InsertarProducto(producto);
        }

        // ✅ Actualizar un producto existente
        public void ActualizarProducto(Products producto)
        {
            dProduct.ActualizarProducto(producto);
        }

        // ✅ Eliminación lógica de un producto
        public void EliminarProducto(int productId)
        {
            dProduct.EliminarProducto(productId);
        }
    }
}
