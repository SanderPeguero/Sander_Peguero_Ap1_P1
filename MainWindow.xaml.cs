using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sander_Peguero_Ap1_P1.UI.Registros;
using Sander_Peguero_Ap1_P1.UI.Consultas;

namespace Sander_Peguero_Ap1_P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Registro_Click(object sender, RoutedEventArgs e){
            
            rProducto registro = new rProducto();
            registro.Show();
        
        }

        private void Consulta_Click(object sender, RoutedEventArgs e){

            cProductos consulta = new cProductos();
            consulta.Show();
        }
    }
}
