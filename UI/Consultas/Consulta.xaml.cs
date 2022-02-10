using System.Windows;
using Sander_Peguero_Ap1_P1.Entidades;
using Sander_Peguero_Ap1_P1.BLL;
using System.Linq;
using System.Collections.Generic;

namespace Sander_Peguero_Ap1_P1.UI.Consultas
{
    public partial class cProductos : Window
    {

        public cProductos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Producto>();

            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))//si no hay criterio, busco todos         
                
                listado = BLL.BLL.GetList(l => true);

            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {

                    case 0: //"ProductoId"

                        listado = BLL.BLL.GetList(l => l.ProductoId.Equals(int.Parse(CriterioTextBox.Text)));
                        break;

                    case 1:   //"Descripcion" 

                        listado = BLL.BLL.GetList(l => l.Descripcion.Contains(CriterioTextBox.Text));
                        break;

                    case 2:   //"Costo" 

                        listado = BLL.BLL.GetList(l => l.Costo.Equals(int.Parse(CriterioTextBox.Text)));
                        break;

                    case 3:   //"Existencia" 

                        listado = BLL.BLL.GetList(l => l.Existencia.Equals(int.Parse(CriterioTextBox.Text)));
                        break;

                    case 4:   //"ValorInventario" 
                    
                        listado = BLL.BLL.GetList(l => l.ValorInventario.Equals(int.Parse(CriterioTextBox.Text)));
                        break;
        
                }
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = listado;

        }

    }
}