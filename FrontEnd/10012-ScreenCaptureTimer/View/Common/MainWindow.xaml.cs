using System.Windows;
using Library.Core.Util.Logger;
using ScreenCaptureTimer.ViewModels;
using ScreenCaptureTimer.View.Configuration;

namespace ScreenCaptureTimer
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Log.Info("Iniciando aplicação...");

            InitializeComponent();

            
        }

        private void Configuracoes_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ConfigurationView());
        }
    }
}
