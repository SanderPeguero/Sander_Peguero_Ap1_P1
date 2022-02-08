using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sander_Peguero_Ap1_P1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    //SegundaParte
    public partial class App : Application
    {
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs args){
            MessageBox.Show($"Ha Ocurrido un Error:( {args.Exception.Message} )", "Error no Controlado", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
