using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapaEntidad;
using CapaNegocio;

namespace lab07calificado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NProduct nProduct;

        public MainWindow()
        {
            InitializeComponent();
            // Inicializamos la capa de negocio
            nProduct = new NProduct();
        }

        // Evento al hacer clic en el botón de filtro
        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el texto ingresado en el TextBox
            string nombre = txtNombre.Text;

            // Verificar que el texto no esté vacío
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                // Llamamos al método de la capa de negocio para listar productos por nombre
                var productosFiltrados = nProduct.ListarProductosPorNombre(nombre);

                // Asignamos la lista filtrada al DataGrid
                dataGridProductos.ItemsSource = productosFiltrados;
            }
            else
            {
                // Si el nombre está vacío, podemos mostrar todos los productos
                MessageBox.Show("Por favor ingrese un nombre para filtrar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}