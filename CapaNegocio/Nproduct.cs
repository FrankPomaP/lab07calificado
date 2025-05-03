using System.Collections.Generic;
using System.Linq;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NProduct
    {
        private Dproducts dProduct = new Dproducts();

        public List<Products> ListarProductosPorNombre(string nombre)
        {
            // Obtener todos los productos de la capa de datos
            var productos = dProduct.ListarProductos();

            // Filtrar los productos que contienen el nombre dado
            var productosFiltrados = productos.Where(x => x.Name.Contains(nombre)).ToList();

            return productosFiltrados;
        }

        // Método adicional para filtrar por precio mínimo
        public List<Products> ListarProductosPorPrecio(decimal precioMinimo)
        {
            var productos = dProduct.ListarProductos();

            var productosFiltrados = productos.Where(x => x.Price >= precioMinimo).ToList();

            return productosFiltrados;
        }
    }
}
