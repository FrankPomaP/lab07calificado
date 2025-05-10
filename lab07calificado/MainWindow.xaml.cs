using System;
using System.Windows;
using CapaEntidad;
using CapaNegocio;

namespace lab07calificado
{
    public partial class MainWindow : Window
    {
        private NProduct nProduct;

        public MainWindow()
        {
            InitializeComponent();
            nProduct = new NProduct();
            CargarProductos();
        }

        private void CargarProductos()
        {
            var productos = nProduct.ListarProductos();
            dataGridProductos.ItemsSource = productos;
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            CargarProductos();
        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                var productosFiltrados = nProduct.ListarProductosPorNombre(nombre);
                dataGridProductos.ItemsSource = productosFiltrados;
            }
            else
            {
                MessageBox.Show("Ingrese un nombre para filtrar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var producto = new Products
                {
                    Name = txtNombre.Text,
                    Price = decimal.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    Active = true
                };

                nProduct.InsertarProducto(producto);
                MessageBox.Show("Producto insertado correctamente.");
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProductos.SelectedItem is Products productoSeleccionado)
            {
                try
                {
                    productoSeleccionado.Name = txtNombre.Text;
                    productoSeleccionado.Price = decimal.Parse(txtPrecio.Text);
                    productoSeleccionado.Stock = int.Parse(txtStock.Text);

                    nProduct.ActualizarProducto(productoSeleccionado);
                    MessageBox.Show("Producto actualizado.");
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para actualizar.");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProductos.SelectedItem is Products productoSeleccionado)
            {
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de eliminar este producto?", "Confirmación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    nProduct.EliminarProducto(productoSeleccionado.ProductId);
                    MessageBox.Show("Producto eliminado.");
                    CargarProductos();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
            }
        }

        // Manejar la selección de productos en el DataGrid
        private void DataGridProductos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGridProductos.SelectedItem is Products productoSeleccionado)
            {
                // Rellenar los campos con los datos del producto seleccionado
                txtNombre.Text = productoSeleccionado.Name;
                txtPrecio.Text = productoSeleccionado.Price.ToString();
                txtStock.Text = productoSeleccionado.Stock.ToString();
            }
        }
    }
}
