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

            // DataGrid.ItemsSource = null;
            // DataGrid.ItemsSource = listado;

        }

    }
}