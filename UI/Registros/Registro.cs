using System.Windows;
using Sander_Peguero_Ap1_P1.Producto;
using Sander_Peguero_Ap1_P1.BLL;

namespace Sander_Peguero_Ap1_P1.UI.Registros
{
    public partial class rEntidad : Window
    {
        private Producto producto = new Producto();

        public rEntidad()
        {
            InitializeComponent();

            this.DataContext = producto;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.producto;
        }
         private void Limpiar()
        {
            this.producto = new Producto();
            this.DataContext = producto;
        }

        private bool Validar()
        {
            bool esValido = true;

            return esValido;
        }
         private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = BLL.Buscar(this.producto.ProductoId);

            if (encontrado != null)
            {
                this.producto = encontrado;
                Cargar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro el libro!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            paso = BLL.Guardar(producto);

            if (paso)
                MessageBox.Show("Libro guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar el libro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (BLL.Eliminar(producto.EntidadId))
            {
                Limpiar();
                MessageBox.Show("Libro eliminado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar el libro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}