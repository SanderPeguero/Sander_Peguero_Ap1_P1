using System;
using System.Windows.Input;
using System.Windows;
using Sander_Peguero_Ap1_P1.Entidades;
using Sander_Peguero_Ap1_P1.BLL;

namespace Sander_Peguero_Ap1_P1.UI.Registros
{
    public partial class rProducto : Window
    {
        private Producto producto = new Producto();

        public rProducto()
        {

            InitializeComponent();

            producto.ProductoId = 1;
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

        private void Buscar(Producto product)
        {

            var encontrado = BLL.BLL.Buscar(product.ProductoId);

            if (encontrado != null)
            {

                this.producto = encontrado;
                Cargar();

            }
            else
            {

                Limpiar();
                MessageBox.Show("No Se Encontro en la Base de Datos", "Base de Datos", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void ProductoIdEnterEvent(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {

                producto.ProductoId = int.Parse(ProductoIdTextBox.Text);
                Buscar(this.producto);

            }
            else
            {

                return;

            }

        }

        private void SumaAutomatica(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                
                producto.ProductoId = int.Parse(ProductoIdTextBox.Text);
                producto.Descripcion = DescripcionTextBox.Text;
                producto.Costo = int.Parse(CostoTextBox.Text);
                producto.Existencia = int.Parse(ExistenciaTextBox.Text);
                producto.ValorInventario = int.Parse(ValorInventarioTextBox.Text);

                if (producto.Costo < 0)
                {

                    CostoTextBox.Focus();
                    MessageBox.Show("El Costo del Producto no Puede Ser Menor que 1", "Error en Costo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;

                }

                if (producto.Existencia < 0)
                {

                    ExistenciaTextBox.Focus();
                    MessageBox.Show("La Cantidad en Existencia no Puede Ser Menor que 1", "Error en Existencia", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;

                }

                int Costo = int.Parse(CostoTextBox.Text);
                int Existencia = int.Parse(ExistenciaTextBox.Text);

                ValorInventarioTextBox.Text = (Costo * Existencia).ToString();

            }
            else
            {

                return;

            }

        }

        private bool Validar()
        {

            bool esValido = true;

            producto.ProductoId = int.Parse(ProductoIdTextBox.Text);
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Costo = int.Parse(CostoTextBox.Text);
            producto.Existencia = int.Parse(ExistenciaTextBox.Text);
            producto.ValorInventario = int.Parse(ValorInventarioTextBox.Text);

            if (producto.ProductoId < -1)
            {

                esValido = false;
                ProductoIdTextBox.Focus();
                MessageBox.Show("El Id del Producto no Puede Ser Menor que 0", "Error en Producto Id", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (BLL.BLL.Existe(producto.ProductoId))
            {

                esValido = false;
                ProductoIdTextBox.Focus();
                MessageBox.Show("El Id del Producto ya Existe en la Base de Datos", "Error en Base de Datos", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (string.IsNullOrEmpty(producto.Descripcion))
            {

                esValido = false;
                DescripcionTextBox.Focus();
                MessageBox.Show("La Descripcion del Producto no Puede Estar en Blanco", "Error en Descripcion", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (BLL.BLL.Existe(producto.Descripcion))
            {

                esValido = false;
                DescripcionTextBox.Focus();
                MessageBox.Show("No Pueden Existir 2 Descripciones Iguales en la Base de Datos", "Error en Descripcion", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (producto.Costo < 0)
            {

                esValido = false;
                CostoTextBox.Focus();
                MessageBox.Show("El Costo del Producto no Puede Ser Menor que 1", "Error en Costo", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (producto.Existencia < 0)
            {

                esValido = false;
                ExistenciaTextBox.Focus();
                MessageBox.Show("La Cantidad en Existencia no Puede Ser Menor que 1", "Error en Existencia", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            return esValido;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

            var encontrado = BLL.BLL.Buscar(this.producto.ProductoId);

            if (encontrado != null)
            {

                this.producto = encontrado;
                Cargar();

            }
            else
            {

                Limpiar();
                MessageBox.Show("No Se Encontro en la Base de Datos", "Base de Datos", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

            Limpiar();

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!Validar())
            {

                return;

            }
            else
            {

                producto.ProductoId = int.Parse(ProductoIdTextBox.Text);
                producto.Descripcion = DescripcionTextBox.Text;
                producto.Costo = int.Parse(CostoTextBox.Text);
                producto.Existencia = int.Parse(ExistenciaTextBox.Text);
                producto.ValorInventario = int.Parse(ValorInventarioTextBox.Text);

                if (BLL.BLL.Guardar(producto))
                {

                    MessageBox.Show("Guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {

                    MessageBox.Show("No se ha Podido Guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
        }

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {

            BLL.BLL.Eliminar(producto.ProductoId);

            producto.ProductoId = int.Parse(ProductoIdTextBox.Text);
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Costo = int.Parse(CostoTextBox.Text);
            producto.Existencia = int.Parse(ExistenciaTextBox.Text);
            producto.ValorInventario = int.Parse(ValorInventarioTextBox.Text);

            if (!Validar())
            {

                return;

            }

            if (BLL.BLL.Guardar(producto))
            {

                MessageBox.Show("Editado con Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {

                MessageBox.Show("No se ha Podido Editar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            producto.ProductoId = int.Parse(ProductoIdTextBox.Text);

            if (BLL.BLL.Eliminar(producto.ProductoId))
            {

                Limpiar();
                MessageBox.Show("Eliminado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {

                MessageBox.Show("No se ha Podido Eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

    }
}