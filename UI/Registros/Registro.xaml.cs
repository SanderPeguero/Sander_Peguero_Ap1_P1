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

        //METODOS
        private void Cargar()
        {

            this.DataContext = null;
            this.DataContext = this.producto;

        }

        private void Recargar()
        {
            
            producto.ProductoId = int.Parse(ProductoIdTextBox.Text);
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Existencia = int.Parse(CostoTextBox.Text);
            producto.Existencia = int.Parse(ExistenciaTextBox.Text);
            producto.ValorInventario = int.Parse(ValorInventarioTextBox.Text);

        }

        private void Limpiar()
        {

            this.producto = new Producto();
            this.DataContext = producto;

        }

        private void Buscar(Producto product)
        {

            Producto encontrado = BLL.BLL.Buscar(product.ProductoId);

            if (encontrado != null)
            {

                this.producto = encontrado;
                Cargar();

            }
            else
            {

                MessageBox.Show("No Se Encontro en la Base de Datos", "Base de Datos", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        //BOTONES
        private void BuscarButton_Click(object sender, RoutedEventArgs e) //Buscar
        {

            Buscar(producto);

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e) //Nuevo
        {

            Limpiar();

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e) //Guardar
        {

            if (!Validar())
                return;

            BLL_Method_Selector(1);

        }

        private void EditarButton_Click(object sender, RoutedEventArgs e) //Editar
        {

            BLL.BLL.Eliminar(producto.ProductoId);

            if (!Validar())
                return;

            BLL_Method_Selector(2);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e) //Eliminar
        {

            producto.ProductoId = int.Parse(ProductoIdTextBox.Text);

            BLL_Method_Selector(3);

        }

        //EVENTOS CON ENTER

        private void ProductoId_EnterEvent(object sender, KeyEventArgs e) //Busca el ID Inmediatamente Despues de Presionar Enter
        {

            if (e.Key == Key.Return)
            {

                producto.ProductoId = int.Parse(ProductoIdTextBox.Text);
                Buscar(producto);

            }
            else
            {

                return;

            }

        }

        private void Automatic_ValorInventario_EnterEvent(object sender, KeyEventArgs e) //El Sistema Calcula el Valor de ValorInventario
        {

            if (e.Key == Key.Return)
            {
                
                //Aqui se Valida si el Usuario Intento Guardar con un Textbox de Costo o Existencia Vacio
                int Costo = string.IsNullOrEmpty(CostoTextBox.Text) ? 0 : int.Parse(CostoTextBox.Text);
                int Existencia =  string.IsNullOrEmpty(ExistenciaTextBox.Text) ? 0 : int.Parse(ExistenciaTextBox.Text);

                if (Costo < 1)
                {

                    CostoTextBox.Focus();
                    MessageBox.Show("El Costo del Producto no Puede Ser Menor que 1", "Error en Costo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;

                }

                if (Existencia < 1)
                {

                    ExistenciaTextBox.Focus();
                    MessageBox.Show("La Cantidad en Existencia no Puede Ser Menor que 1", "Error en Existencia", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;

                }

                ValorInventarioTextBox.Text = (Costo * Existencia).ToString();

            }
            else
                return;


        }

        //VALIDACIONES

        private bool Validar()
        {

            bool esValido = true;

            Recargar();

            if (producto.ProductoId < -1) //ID Menor que 0
                esValido = Validar_Message_Selector(1);

            else if (BLL.BLL.Existe(producto.ProductoId)) //ID No Existe en la Base de Datos
                esValido = Validar_Message_Selector(2);
    
            else if (string.IsNullOrEmpty(DescripcionTextBox.Text)) //Descripcion en Blanco
                esValido = Validar_Message_Selector(3);     

            else if (BLL.BLL.Existe(producto.Descripcion)) //Descripcion Repetida en Base de Datos
                esValido = Validar_Message_Selector(4);

            else if (producto.Costo < 0) //Costo es Menor que 0
                esValido = Validar_Message_Selector(5);

            else if (producto.Existencia < 0) //Existencia es Menor que 0
                esValido = Validar_Message_Selector(6);

            return esValido;

        }

        private bool Validar_Message_Selector(int Message)
        {

            string Mensaje = "";
            string Titulo = "";

            switch (Message)
            {

                case 1:   //ID Menor que 0

                    ProductoIdTextBox.Focus();
                    Mensaje = "El Id del Producto no Puede Ser Menor que 0";
                    Titulo = "Error en Producto Id";

                    break;

                case 2:   //ID No Existe en la Base de Datos
                    
                    ProductoIdTextBox.Focus();
                    Mensaje = "El Id del Producto ya Existe en la Base de Datos";
                    Titulo = "Error en Base de Datos";

                    break;

                case 3:   //Descripcion en Blanco

                    DescripcionTextBox.Focus();
                    Mensaje = "La Descripcion del Producto no Puede Estar en Blanco";
                    Titulo = "Error en Descripcion";
                    break;

                 case 4:   //Descripcion Repetida en Base de Datos

                    DescripcionTextBox.Focus();
                    Mensaje = "No Pueden Existir 2 Descripciones Iguales en la Base de Datos";
                    Titulo = "Error en Descripcion";
                    break;
                
                 case 5:   //Costo es Menor que 0

                    CostoTextBox.Focus();
                    Mensaje = "El Costo del Producto no Puede Ser Menor que 1"; 
                    Titulo = "Error en Costo";
                    break;

                 case 6:   //Existencia es Menor que 0

                    ExistenciaTextBox.Focus();
                    Mensaje = "La Cantidad en Existencia no Puede Ser Menor que 1";
                    Titulo = "Error en Existencia";
                    break;
        
            }

            MessageBox.Show(Mensaje, Titulo, MessageBoxButton.OK, MessageBoxImage.Information);
            return false;

        }

        //BLL
        private void BLL_Method_Selector(int Method) //Invoca un Metodo de la BLL
        {

            bool Successful = false;

            //Preguntar al profesor como inicializar dos variables a la vez sin que me quite punto
            string Mensaje_Exito = "", Titulo_Exito = "Exito";//Textos de Exito
            string Mensaje_Error = "", Titulo_Error = "Error";//Textos de Error

            switch (Method)
            {

                case 1://Guardar

                    Successful = BLL.BLL.Guardar(producto);
                    Mensaje_Exito = "Guardado con éxito";
                    Mensaje_Error = "No se ha podido Guardar";

                    break;

                case 2://Editar

                    Successful = BLL.BLL.Guardar(producto);
                    Mensaje_Exito = "Editado con éxito";
                    Mensaje_Error = "No se ha podido Editar";

                    break;

                case 3://Eliminar

                    Successful = BLL.BLL.Eliminar(producto.ProductoId);
                    Mensaje_Exito = "Eliminado con éxito";
                    Mensaje_Error = "No se ha podido Eliminar";
                    Limpiar();

                    break;

            }

            if (Successful)
            {

                MessageBox.Show(Mensaje_Exito, Titulo_Exito, MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show(Mensaje_Error, Titulo_Error, MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

    }
}