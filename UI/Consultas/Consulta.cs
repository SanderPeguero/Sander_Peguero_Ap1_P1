using System.Windows;
using Sander_Peguero_Ap1_P1.Entidades;
using Sander_Peguero_Ap1_P1.BLL;
using System.Linq;
using System.Collections.Generic;

namespace Clase2.UI.Consultas
{
    public partial class cProducto : Window
    {

        public cProducto()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Producto>();

            // if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))//si no hay criterio, busco todos         
            //     listado = ;
            // else
            // {
            //     switch (FiltroComboBox.SelectedIndex)
            //     {
            //         case 0: //"Titulo"
            //             listado = ;
            //             break;
            //         case 1:   //"Grupo" 
            //             listado = ;
            //             break;
            //     }
            // }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = listado;

        }

    }
}